using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodBlockScript : MonoBehaviour
{
    public GameObject woodBlock;
    private int numCollisions = 0;
    public SpriteRenderer changeWoodBlock;
    public Sprite[] woodSprite;

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
            Destroy(woodBlock);
            scoreManager.totalScore = scoreManager.totalScore + 50;
        }

        if (collision.relativeVelocity.magnitude > 4 && collision.relativeVelocity.magnitude < 29)
        {
            numCollisions++;
            changeWoodBlock.sprite = woodSprite[1];
        }

        if (collision.relativeVelocity.magnitude > 29 && numCollisions == 2)
        {
            Destroy(woodBlock);
            scoreManager.totalScore = scoreManager.totalScore + 30;
        }

        if(numCollisions == 2)
        {
            if(collision.relativeVelocity.magnitude > 4 && collision.relativeVelocity.magnitude < 29)
            {
                Destroy(woodBlock);
                scoreManager.totalScore = scoreManager.totalScore + 10;
            }
        }


        if (numCollisions > 3)
        {
            Destroy(woodBlock);
            scoreManager.totalScore = scoreManager.totalScore + 5;
        }
    }

}
