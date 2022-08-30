using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject[] puzzleBlocks;
    bool canHover = true;
    bool canSwap = false;
    bool canHover2 = false;

    public Text[] puzzleBlockTexts;

    int[] puzzleBlockVals = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    int temp1Pos;
    int temp2Pos;
    int temp1Val;
    int temp2Val;

    int sum1;
    int sum2;
    int sum3;
    int sum4;
    int sum5;

    public Text sum1Text;
    public Text sum2Text;
    public Text sum3Text;
    public Text sum4Text;
    public Text sum5Text;

    int[] puzzleSolve = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    int tempSolve;

    public Text[] solvedTexts;

    public Text sum1SolvedText;
    public Text sum2SolvedText;
    public Text sum3SolvedText;
    public Text sum4SolvedText;
    public Text sum5SolvedText;

    int sum1Solved;
    int sum2Solved;
    int sum3Solved;
    int sum4Solved;
    int sum5Solved;

    public Text showSolvedText;

    int numHints = 3;

    public Text hintText;

    public Text scoreText;

    public Sprite cursorSprite;

    Vector2 centre = new Vector2(0, 0);

    public Animator catAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorSprite.texture, centre, CursorMode.Auto);

        shuffleArray();
        for (int i = 0; i < puzzleSolve.Length; i++)
        {
            Debug.Log("Pos " + i + " Val: " + puzzleSolve[i]);
            solvedTexts[i].text = puzzleSolve[i].ToString();
        }

        sum1Solved = puzzleSolve[0] + puzzleSolve[1] + puzzleSolve[2];
        sum1SolvedText.text = sum1Solved.ToString();
        sum2Solved = puzzleSolve[0] + puzzleSolve[4] + puzzleSolve[2];
        sum2SolvedText.text = sum2Solved.ToString();
        sum3Solved = puzzleSolve[3] + puzzleSolve[4] + puzzleSolve[5];
        sum3SolvedText.text = sum3Solved.ToString();
        sum4Solved = puzzleSolve[3] + puzzleSolve[6] + puzzleSolve[5];
        sum4SolvedText.text = sum4Solved.ToString();
        sum5Solved = puzzleSolve[1] + puzzleSolve[4] + puzzleSolve[6];
        sum5SolvedText.text = sum5Solved.ToString();

        foreach (Text solvedText in solvedTexts)
        {
            solvedText.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        sum1 = puzzleBlockVals[0] + puzzleBlockVals[1] + puzzleBlockVals[2];
        sum1Text.text = sum1.ToString();
        sum2 = puzzleBlockVals[0] + puzzleBlockVals[4] + puzzleBlockVals[2];
        sum2Text.text = sum2.ToString();
        sum3 = puzzleBlockVals[3] + puzzleBlockVals[4] + puzzleBlockVals[5];
        sum3Text.text = sum3.ToString();
        sum4 = puzzleBlockVals[3] + puzzleBlockVals[6] + puzzleBlockVals[5];
        sum4Text.text = sum4.ToString();
        sum5 = puzzleBlockVals[1] + puzzleBlockVals[4] + puzzleBlockVals[6];
        sum5Text.text = sum5.ToString();

        if(sum1 == sum1Solved)
        {
            sum1Text.color = new Color(90f/255f, 224f/255f, 56f/255f);
        }
        else
        {
            sum1Text.color = new Color(255f/255f, 134f/255f, 141f/255f);
        }

        if (sum2 == sum2Solved)
        {
            sum2Text.color = new Color(90f / 255f, 224f / 255f, 56f / 255f);
        }
        else
        {
            sum2Text.color = new Color(255f / 255f, 134f / 255f, 141f / 255f);
        }

        if (sum3 == sum3Solved)
        {
            sum3Text.color = new Color(90f / 255f, 224f / 255f, 56f / 255f);
        }
        else
        {
            sum3Text.color = new Color(255f / 255f, 134f / 255f, 141f / 255f);
        }

        if (sum4 == sum4Solved)
        {
            sum4Text.color = new Color(90f / 255f, 224f / 255f, 56f / 255f);
        }
        else
        {
            sum4Text.color = new Color(255f / 255f, 134f / 255f, 141f / 255f);
        }

        if (sum5 == sum5Solved)
        {
            sum5Text.color = new Color(90f / 255f, 224f / 255f, 56f / 255f);
        }
        else
        {
            sum5Text.color = new Color(255f / 255f, 134f / 255f, 141f / 255f);
        }


        if (numHints == 3)
        {
            scoreText.text = "SCORE: 100%";
        }

        if (numHints == 2)
        {
            scoreText.text = "SCORE: 75%";
            scoreText.color = new Color(161f/255f, 241f/255f, 42f/255f);
        }

        if (numHints == 1)
        {
            scoreText.text = "SCORE: 60%";
            scoreText.color = new Color(241f/255f, 238f/255f, 42f/255f);
        }

        if (numHints < 1)
        {
            scoreText.text = "SCORE: 50%";
            scoreText.color = new Color(241f/255f, 181f/255f, 42f/255f);
        }

        if (sum1 == sum1Solved && sum2 == sum2Solved && sum3 == sum3Solved && sum4 == sum4Solved && sum5 == sum5Solved)
        {
            catAnimator.SetBool("isHappy", true);
        }
        else
        {
            catAnimator.SetBool("isHappy", false);
        }

    }

    public void clickFunction(GameObject puzzleBlock)
    {
        //Debug.Log("Clicked image");
        //Debug.Log("Clicked puzzblock:" + puzzleBlock.gameObject.name);
        

        int index = System.Array.IndexOf(puzzleBlocks, puzzleBlock);
        Debug.Log("Clicked: " + puzzleBlock.gameObject.name + " With Index: " + index);

        if (canHover)
        {
            temp1Pos = index;
            temp1Val = puzzleBlockVals[index];
            
            switch (index)
            {
                case 0:
                    //canHover = false;
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[1].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[3].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;

                    break;
                case 1:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[0].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[2].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;

                    break;
                case 2:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[1].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[5].gameObject.GetComponent<Image>().color = Color.green;
                    break;
                case 3:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[0].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[6].gameObject.GetComponent<Image>().color = Color.green;
                    break;
                case 4:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[0].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[1].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[2].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[3].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[5].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[6].gameObject.GetComponent<Image>().color = Color.green;
                    break;
                case 5:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[2].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[6].gameObject.GetComponent<Image>().color = Color.green;
                    break;
                case 6:
                    canHover = false;
                    canHover2 = true;
                    canSwap = true;
                    changeToWhite();
                    puzzleBlocks[3].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[4].gameObject.GetComponent<Image>().color = Color.green;
                    puzzleBlocks[5].gameObject.GetComponent<Image>().color = Color.green;
                    break;
            }
        }else if (canSwap)
        {
            temp2Pos = index;
            temp2Val = puzzleBlockVals[index];

            if (puzzleBlocks[index].gameObject.GetComponent<Image>().color == /*Color.green*/ new Color(62f / 255f, 110f / 255f, 49f / 255f))
            {
                Debug.Log("Swap Now");
                canSwap = false;
                canHover2 = false;
                canHover = true;
                changeToWhite();

                //temp2 = puzzleBlockVals[index];
                Debug.Log("1stTemp: " + temp1Pos + " 2ndTemp: " + temp2Pos);

                //swapping the values
                puzzleBlockVals[temp1Pos] = temp2Val;
                puzzleBlockTexts[temp1Pos].text = temp2Val.ToString();
                puzzleBlockVals[temp2Pos] = temp1Val;
                puzzleBlockTexts[temp2Pos].text = temp1Val.ToString();
                

            }
            else
            {
                Debug.Log("No swap");
                canSwap = false;
                canHover2 = false;
                canHover = true;
                changeToWhite();
            }
                
        }

    }

    public void onHoverEnter(GameObject puzzleBlock)
    {
        if (canHover)
        {
            puzzleBlock.gameObject.GetComponent<Image>().color = Color.grey;
        }

        if (canHover2)
        {
            if (puzzleBlock.gameObject.GetComponent<Image>().color == Color.green)
            {
                puzzleBlock.gameObject.GetComponent<Image>().color = new Color(62f/255f, 110f/255f, 49f/255f);
            }
            if (puzzleBlock.gameObject.GetComponent<Image>().color == Color.white)
            {
                puzzleBlock.gameObject.GetComponent<Image>().color = Color.grey;
            }
        }
        
    }

    public void onHoverExit(GameObject puzzleBlock)
    {
        if (canHover)
        {
            puzzleBlock.gameObject.GetComponent<Image>().color = Color.white;
        }

        if (canHover2)
        {
            if (puzzleBlock.gameObject.GetComponent<Image>().color == new Color(62f / 255f, 110f / 255f, 49f / 255f))
            {
                puzzleBlock.gameObject.GetComponent<Image>().color = Color.green;
            }
            if (puzzleBlock.gameObject.GetComponent<Image>().color == Color.grey)
            {
                puzzleBlock.gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        
    }

    public void changeToWhite()
    {
        foreach (GameObject puzzleBlock in puzzleBlocks)
        {
            puzzleBlock.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void shuffleArray()
    {
        for (int i = 0; i < puzzleSolve.Length; i++)
        {
            int rand = Random.Range(0, puzzleSolve.Length);
            tempSolve = puzzleSolve[rand];
            puzzleSolve[rand] = puzzleSolve[i];
            puzzleSolve[i] = tempSolve;
        }
    }

    public void showSolvedPuzzle()
    {
        foreach (Text solvedText in solvedTexts)
        {
            if (!solvedText.gameObject.activeSelf)
            {
                solvedText.gameObject.SetActive(true);
                showSolvedText.text = "HIDE";
            }
            else
            {
                solvedText.gameObject.SetActive(false);
                showSolvedText.text = "SHOW";
            }
            
        }
    }

    public void showHint()
    {
        if (numHints == 3)
        {
            solvedTexts[0].gameObject.SetActive(true);
        }
        if (numHints == 2)
        {
            solvedTexts[5].gameObject.SetActive(true);
        }
        if (numHints == 1)
        {
            solvedTexts[4].gameObject.SetActive(true);
        }
        numHints--;
        numHints = Mathf.Clamp(numHints, 0, 3);
        hintText.text = "HINTS: " + numHints.ToString();
        Debug.Log("Hints left: " + numHints);
    }

}
