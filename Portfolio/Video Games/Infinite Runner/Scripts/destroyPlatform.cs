using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPlatform : MonoBehaviour
{
    public float showTransformY;
    //public Transform destroyPlatformPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showTransformY = gameObject.transform.position.y;
        if (gameObject.transform.position.y <= -7)
        {
            Debug.Log("destroyed platform");
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag =="destroyPlatformPoint")
        {
            Destroy(gameObject);
            Debug.Log("destroyed platform");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "destroyPlatformPoint")
        {
            Destroy(gameObject);
            Debug.Log("destroyed platform");
        }
    }*/
}
