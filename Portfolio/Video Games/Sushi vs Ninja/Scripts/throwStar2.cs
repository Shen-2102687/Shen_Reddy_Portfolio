using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwStar2 : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rbStar;
    public GameObject redStar;
    public float bluePower = 35f;

    public static int numStarsThrown = 0;

    public static float starVelocity;
    public Text velocityText;

    public static float timer = 0;

    private int starsLeft = 4;
    private int nextStar = 0;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera camRef;

    Vector2 force;

    Vector3 startPoint;
    Vector3 endPoint;

    lineForce lF;

    private bool starThrown = false;

    public SpriteRenderer changeStar;
    public Sprite[] starSprite;

    //public LineRenderer lineColour;

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
        nextStar = 0;
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

                if (timer > 2f)
                {
                    gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    gameObject.transform.position = new Vector3(-6.05f, -1.17f);
                    starThrown = false;
                    Destroy(GameObject.Find("RedStar" + starsLeft.ToString()));
                    starsLeft--;
                    nextStar++;
                    //nextThrow = true;

                }
            }
            else if (rbStar.velocity.magnitude > 0)
            {
                timer = 0;
            }

        }

        if (GameManager2.gameOver == true)
        {
            redStar.SetActive(false);
        }

        if (GameManager2.gameWon == true)
        {
            redStar.SetActive(false);
        }

        if(nextStar == 1)
        {
            changeStar.sprite = starSprite[1];
            //Gradient blueGradient = new Gradient();
            //blueGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0f) }, new GradientAlphaKey[] { new GradientAlphaKey(2f, 0.0f) });
            //lineColour.colorGradient = blueGradient;
        }

        if (nextStar == 3)
        {
            changeStar.sprite = starSprite[0];
        }

        if(nextStar > 0 && nextStar < 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbStar.AddForce(Vector3.right * bluePower , ForceMode2D.Impulse);
            }
        }
    }
}

