using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushi2Script : MonoBehaviour
{
    public GameObject sushi2;
    private int numCollisions = 0;
    public static int numSushiDestroyed = 0;
    public SpriteRenderer changeSushi;
    public Sprite[] sushi2Sprite;


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
            Destroy(sushi2);
            scoreManager.totalScore = scoreManager.totalScore + 400;
            numSushiDestroyed++;
        }


        if (collision.relativeVelocity.magnitude > 3 && collision.relativeVelocity.magnitude < 29)
        {
            numCollisions++;

            changeSushi.sprite = sushi2Sprite[1];
        }

        if (collision.relativeVelocity.magnitude > 29 && numCollisions == 2)
        {
            Destroy(sushi2);
            scoreManager.totalScore = scoreManager.totalScore + 200;
            numSushiDestroyed++;
        }

        if (numCollisions > 3)
        {
            Destroy(sushi2);
            scoreManager.totalScore = scoreManager.totalScore + 100;
            numSushiDestroyed++;
        }
    }
}
