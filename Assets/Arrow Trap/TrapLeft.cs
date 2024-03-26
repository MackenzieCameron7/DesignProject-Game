


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLeft : MonoBehaviour
{
    public GameObject Arrow;
    public Transform Trap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(Arrow, Trap.position, Trap.rotation);
            obj.transform.localScale = new Vector3(-8, 8, 8);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(-15, 2, 0);

        }
    }
}
