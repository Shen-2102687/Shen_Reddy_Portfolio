using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public Text winText;
    public Text gameOverText;

    public Canvas pauseCanvas;
    private bool paused = true;

    public static bool gameOver = false;
    public static bool gameWon = false;

    public Image Star1;
    public Image Star2;
    public Image Star3;

    public Button menu;
    public Button replay;
    public Button level2;




    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        gameOverText.enabled = false;

        gameOver = false;
        gameWon = false;
        paused = true;

        Star1.enabled = false;
        Star2.enabled = false;
        Star3.enabled = false;

        menu.gameObject.SetActive(false);
        replay.gameObject.SetActive(false);
        level2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sushi2Script.numSushiDestroyed == 4 && !gameOver)
        {
            winText.enabled = true;
            gameWon = true;
            menu.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);
            level2.gameObject.SetActive(true);

            if (scoreManager.totalScore >= 300)
            {
                Star1.enabled = true;

            }
            if (scoreManager.totalScore >= 700)
            {
                Star2.enabled = true;
            }
            if (scoreManager.totalScore >= 900)
            {
                Star3.enabled = true;
            }
        }

        if (throwStar2.numStarsThrown == 5 && sushi2Script.numSushiDestroyed < 4)
        {
            if (throwStar2.timer > 0)
            {
                gameOverText.enabled = true;
                gameOver = true;
                menu.gameObject.SetActive(true);
                replay.gameObject.SetActive(true);
            }


        }

        if (!paused)
        {
            Time.timeScale = 0.00001f;
            pauseCanvas.enabled = true;
        }
        if (paused)
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
    }
}
