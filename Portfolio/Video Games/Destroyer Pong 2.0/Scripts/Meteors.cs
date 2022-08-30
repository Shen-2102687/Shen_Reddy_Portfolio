using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject Meteor;
    public float spawnStart;
    public float spawnNext;
    public int numMeteors;
    public float i = 0;
    public Rigidbody2D rbMeteor;
  
    

 

    // Start is called before the first frame update
    void Start()
    {
        spawnMeteor();
        InvokeRepeating("spawnMeteor", spawnStart, spawnNext);
        rbMeteor = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void spawnMeteor()
    {
        if (AlienScript.gameOver == false)
        {
            for (int i = 0; i < numMeteors; i++)
            {
                Vector3 spawn = new Vector3(Random.Range(-7.7422f, 7.735f), 5, 0);
                Instantiate(Meteor, spawn, Quaternion.identity);
            }

        }
    }



    
        }
      
    

