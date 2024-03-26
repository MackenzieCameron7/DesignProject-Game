using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D= GetComponent<Rigidbody2D>();
        rigidBody2D.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && rigidBody2D.angularVelocity > 0 && rigidBody2D.angularVelocity < velocityThreshold)
        {
            rigidBody2D.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && rigidBody2D.angularVelocity < 0 && rigidBody2D.angularVelocity > velocityThreshold * -1)
        {
            rigidBody2D.angularVelocity = velocityThreshold * -1;
        }
    }
}
