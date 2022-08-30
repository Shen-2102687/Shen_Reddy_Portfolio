using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalBlockScript : MonoBehaviour
{
    public GameObject metalBlock;
    private int numCollisions = 0;
    public SpriteRenderer changeMetalBlock;
    public Sprite[] metalSprite;

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
        if (collision.relativeVelocity.magnitude > 34)
        {
            Destroy(metalBlock);
            scoreManager.totalScore = scoreManager.totalScore + 60;//50
        }

        if (collision.relativeVelocity.magnitude > 6 && collision.relativeVelocity.magnitude < 34)
        {
            numCollisions++;
            changeMetalBlock.sprite = metalSprite[1];
        }

        if (collision.relativeVelocity.magnitude > 34 && numCollisions == 2)
        {
            Destroy(metalBlock);
            scoreManager.totalScore = scoreManager.totalScore + 40;//30
        }

        if (numCollisions == 2)
        {
            if (collision.relativeVelocity.magnitude > 6 && collision.relativeVelocity.magnitude < 29)
           {
               Destroy(metalBlock);
               scoreManager.totalScore = scoreManager.totalScore + 25;
           }
        }


        if (numCollisions > 3)
        {
            Destroy(metalBlock);
            scoreManager.totalScore = scoreManager.totalScore + 20;
        }
    }
}
