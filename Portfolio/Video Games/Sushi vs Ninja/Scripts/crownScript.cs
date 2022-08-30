using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crownScript : MonoBehaviour
{
    public GameObject crown;
    private int numCollisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        numCollisions = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 29)
        {
            Destroy(crown);
            scoreManager.totalScore = scoreManager.totalScore + 50;
        }


        if (collision.relativeVelocity.magnitude > 3 && collision.relativeVelocity.magnitude < 29)
        {
            numCollisions++;
        }

        if (collision.relativeVelocity.magnitude > 29 && numCollisions == 2)
        {
            Destroy(crown);
            scoreManager.totalScore = scoreManager.totalScore + 30;
        }

        if (numCollisions > 3)
        {
            Destroy(crown);
            scoreManager.totalScore = scoreManager.totalScore + 10;
        }
    }
}
