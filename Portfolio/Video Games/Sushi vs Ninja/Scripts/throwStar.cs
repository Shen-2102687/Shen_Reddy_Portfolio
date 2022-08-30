using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwStar : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rbStar;
    public GameObject redStar;

    public static int numStarsThrown = 0;

    public static float starVelocity;
    public Text velocityText;

    public static float timer = 0;

    private int starsLeft = 4;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera camRef;

    Vector2 force;

    Vector3 startPoint;
    Vector3 endPoint;

    lineForce lF;

    private bool starThrown = false;
   // private bool nextThrow = false;


    // Start is called before the first frame update
    void Start()
    {
        camRef = Camera.main;
        lF = GetComponent<lineForce>();
        redStar.SetActive(true);
        numStarsThrown = 0;
        starsLeft = 4;
        timer = 0;
        redStar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        starVelocity = rbStar.velocity.magnitude;
        velocityText.text = "Star Velocity: " + starVelocity.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            startPoint = camRef.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = camRef.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rbStar.AddForce(force * power, ForceMode2D.Impulse);
            lF.EndLine();
            starThrown = true;
            numStarsThrown++;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = camRef.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            lF.RenderLine(startPoint, currentPoint);
        }

        if (starThrown)
        {
            if (Mathf.Approximately(rbStar.velocity.magnitude, 0))
            {
                timer += Time.deltaTime;

                if(timer > 2f)
                {
                    gameObject.transform.eulerAngles= new Vector3(0, 0, 0);
                    gameObject.transform.position = new Vector3(-6.05f, -1.17f);
                    starThrown = false;
                    Destroy(GameObject.Find("RedStar" + starsLeft.ToString()));
                    starsLeft--;
                    //nextThrow = true;
                  
                }
            }
            else if (rbStar.velocity.magnitude > 0)
            {
                timer = 0;
            }
        
        }

        if (gameManagerScript.gameOver == true)
        {
            redStar.SetActive(false);
        }

        if (gameManagerScript.gameWon == true)
        {
            redStar.SetActive(false);
        }
    }



}
