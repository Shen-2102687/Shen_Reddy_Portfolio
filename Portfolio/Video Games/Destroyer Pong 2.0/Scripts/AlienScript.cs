using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienScript : MonoBehaviour
{
    public Rigidbody2D rbAlien;
    public float alienForce;
    private int Count;
    public Text gameOverText;
    public GameObject Alien;
    public static bool gameOver;
    public Button replayButton;
    public Button mainMenuButton;
  
    

    
    // Start is called before the first frame update
    void Start()
    {
        rbAlien = GetComponent<Rigidbody2D>();
        Count = 4;
        gameOverText.enabled = false;
        gameOver = false;
        replayButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, -1);
        rbAlien.AddForce(movement * alienForce);
        rbAlien.velocity = alienForce * (rbAlien.velocity.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bottomBorder")
        {
            rbAlien.transform.position = new Vector3(0, 3, 0);
            Destroy(GameObject.Find("health " + Count.ToString()));
            Count = Count - 1;
            if (Count == 0)
            {
                gameOverText.enabled = true;
                Alien.gameObject.SetActive(false);
                gameOver = true;
                replayButton.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);
            }
        }
        
    }
}
