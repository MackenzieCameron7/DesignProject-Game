using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // Array of game objects to randomly choose from
    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        // Choose a random game object(tiles) from objects array
        // and create one on our spawnpoint
        int random = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[random], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
