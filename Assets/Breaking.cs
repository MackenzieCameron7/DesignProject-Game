using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private bool isHit = false;

    // Update is called once per frame
    void Update()
    {
        if(isHit == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHit = true;
    }
}
