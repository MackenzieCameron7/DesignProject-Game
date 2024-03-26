using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    public float time = 0.0f;
    public float waitTime = 1.0f;

    private bool isCountingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count up time if collided with
        if(isCountingUp == true)
        {
            time += Time.deltaTime;
        }

        // Destroy the Dissolving tile if time is Bigger than wait time
        if (time > waitTime)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Don't start counting up until collision happens
        Debug.Log("colliding");
        isCountingUp = true;
    }

}
