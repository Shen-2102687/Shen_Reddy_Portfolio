using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushi1 : MonoBehaviour
{
    public GameObject Sushi1;
    private int numCollisions = 0;
    public static int numSushiDestroyed = 0;
    public SpriteRenderer changeSushi;
    public Sprite[] sushi1Sprite;


    // Start is called before the first frame update
    void Start()
    {
        numCollisions = 0;
        numSushiDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 29)
        {
            Destroy(Sushi1);
            scoreManager.totalScore = scoreManager.totalScore + 400;
            numSushiDestroyed++;
            //gameManager2.totalSushiDestroyed++;
        }


        if(collision.relativeVelocity.magnitude > 3 && collision.relativeVelocity.magnitude < 29)
        {
            numCollisions++;

            changeSushi.sprite = sushi1Sprite[1];
        }

        if (collision.relativeVelocity.magnitude > 29 && numCollisions == 2)
        {
            Destroy(Sushi1);
            scoreManager.totalScore = scoreManager.totalScore + 200;
            numSushiDestroyed++;
           // gameManager2.totalSushiDestroyed++;
        }

        if (numCollisions > 3)
        {
            Destroy(Sushi1);
            scoreManager.totalScore = scoreManager.totalScore + 100;
            numSushiDestroyed++;
            //gameManager2.totalSushiDestroyed++;
        }
    }
}
