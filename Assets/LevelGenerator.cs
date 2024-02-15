using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Array of starting room positions
    public Transform[] startingPositions;
    
    // Array of rooms
    // index: 0 -> Left Right, 1 -> Left Right Down, 2 -> Left Right Top, 3 -> All 4
    public GameObject[] rooms;

    // Room Movement Variables
    private int direction;
    public float moveAmount;

    // Room placement timer. For visual reference only
    private float timeBetweenRoom;
    public float startTimeBetween = 0.25f;

    // Level Boundary variables
    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;

    private int downCount;

    // Used to only collide with rooms
    public LayerMask room;

    // Start is called before the first frame update
    void Start()
    {
        // Pick a random starting position & put a room there
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        // Random direction to determine where to place next room 1-2: Left, 3-4: Right, 5: Down
        direction = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {   
        // Placing a Room every 0.25 seconds, then moving and repeating
        if (timeBetweenRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBetweenRoom = startTimeBetween;
        }
        else
        {
            timeBetweenRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        // Move right
        if (direction == 1 || direction == 2) {
            // if not clipping the LEFT most boundary, place a room
            if (transform.position.x < maxX)
            {
                // Reset down count, since not going down
                downCount = 0;

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                // Instantiate a random room type 
                int randRoom = Random.Range(0, rooms.Length);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);

                // Make sure rooms arent spawning on top of each other
                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                } else if (direction == 4)
                {
                    direction = 5;
                }
            }  
            else
            {
                direction = 5; // Move DOWN
            }
        }
        // Move Left
        else if (direction == 3 || direction == 4) {
            // if not clipping the RIGHT most boundary, place a room
            if (transform.position.x > minX)
            {
                // Reset down count, since not going down
                downCount = 0;

                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                // Instantiate a random room type
                int randRoom = Random.Range(0, rooms.Length);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);

                // Will not move back onto itself
                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5; // Move DOWN
            }
        }
        // Move Down
        else if (direction == 5) {

            downCount++;

            // if not clipping the BOTTOM of the level
            if (transform.position.y > minY)
            {
                // Used to Override rooms when go9ing down to have a down opening into a room that has an up opening 
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

                // If Room type != to a type of room with a down opening
                if(roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    // if level generator has moved down twice in a row, make sure the top room is an All 4 room
                    if (downCount >= 2)
                    {
                        // Destroy room that spawned that did not have a bottom opening
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        // Delete it 
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        // Replace with one that has a bottom opening 
                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                // Instantiate a room with a top opening 
                int randRoom = Random.Range(2, 4);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);

                // Will not spawn ontop of each other
                direction = Random.Range(1, 6);
            }
            else
            {
                // Stop level generation and make an exit
                stopGeneration = true;
            }
        }
    }
}
