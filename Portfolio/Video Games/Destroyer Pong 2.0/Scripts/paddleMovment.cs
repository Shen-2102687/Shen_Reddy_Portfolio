using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMovment : MonoBehaviour
{

    public float moveMultiplier;
    public GameObject Lazer;
    public Rigidbody2D rbLazer;
    public int numShots;
    public float i = 0;
    public AudioSource lazerSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (Input.GetKey("left"))
        {
            transform.position = transform.position + new Vector3(-moveMultiplier, 0, 0);
            Vector3 newPos = new Vector2( Mathf.Clamp(transform.position.x, -7.7422f, 7.735f), transform.position.y);
            transform.position = newPos;
        }

        if (Input.GetKey("right"))
        {
            transform.position = transform.position + new Vector3(moveMultiplier, 0, 0);
            Vector3 newPos = new Vector2(Mathf.Clamp(transform.position.x, -7.7422f, 7.735f), transform.position.y);
            transform.position = newPos;
        }

        if (Input.GetKeyDown("space"))
        {
            for (i = 0; i < numShots; i++)
            {
                Vector3 fire = new Vector3(GameObject.Find("Paddle").transform.position.x, GameObject.Find("Paddle").transform.position.y, 0);
                Instantiate(Lazer, fire, Quaternion.identity);
                Debug.Log("lazer fired");
            }
            lazerSound.Play();
        }
    }
   // void fireLazer()
   // {
       

   // }
}
