using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoreText;

    public static float scoreCounter;
    public float pointsPerSec = 10;

    public Text highScoreText;
    public static float highScoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = 0;
        highScoreCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter += pointsPerSec * Time.deltaTime;

        scoreText.text = "Score: " + Mathf.Round(scoreCounter);

        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
        }

        highScoreText.text = "Record: " + Mathf.Round(highScoreCounter);
    }
}
