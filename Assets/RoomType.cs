using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;

    // Destroys the object which the script is attached to
    public void RoomDestruction()
    {
        Destroy(gameObject);
    }
}
