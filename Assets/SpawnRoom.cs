using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    // Mask to tell which room is generated
    public LayerMask whatIsRoom;
    public LevelGenerator levelGen;

    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);

        // If a room is still null after main path is made
        if(roomDetection == null && levelGen.stopGeneration == true)
        {
            // Spawn a room 
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);

            // Destroy to stop inifinite generation
            Destroy(gameObject);
        }
    }
}
