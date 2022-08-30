using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerManager : MonoBehaviour
{
    //public GameObject Lazer;
    public Rigidbody2D rbLazer;
    public float lazerForce;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, 1);
        rbLazer.AddForce(movement * lazerForce);
        rbLazer.velocity = lazerForce * (rbLazer.velocity.normalized);
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Destroy(other.gameObject);
            Debug.Log("Lazer Destroyed Meteor destroyed");
            //Score = Score + 1;
            scoreScript.Score = scoreScript.Score + 1;
        }
    }


  
}
