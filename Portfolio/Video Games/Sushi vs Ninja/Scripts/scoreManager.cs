using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int totalScore = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString();

    }
}
