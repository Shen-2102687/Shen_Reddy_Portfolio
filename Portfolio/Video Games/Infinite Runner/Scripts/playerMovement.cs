using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;

    float moveHori = 0f;
    public float moveSpeed = 20f;

    float jumpHeight = 4f;

    public static bool onGround; 
    public Transform groundPoint;
    public float groundRange = 0.1f;
    public LayerMask groundLayer;

    //public GameObject enemyObject;
    //float switchPosition;

    public static float vertMovement;

    public static bool onIce;
    public LayerMask iceLayer;
    Vector2 move;

    public static bool onStuck;
    public LayerMask stuckLayer;

    int numPresses = 0;

    // Start is called before the first frame update
    void Start()
    {
        numPresses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(groundPoint.position, groundRange, groundLayer);

        float forceJump = Mathf.Sqrt(jumpHeight * (-2) * (Physics2D.gravity.y * playerRigidBody.gravityScale));
        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            playerRigidBody.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
            Debug.Log("jumped");
        }*/

        vertMovement = Input.GetAxisRaw("Vertical");
        //playerAnimator.SetBool("onGround", onGround);

        if ((onGround || onIce) &&  /*Input.GetKeyDown(KeyCode.Y)*/ /*Input.GetAxisRaw("Vertical")>=0.5f*/ /*vertMovement >= 0.5f*/ Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity = new Vector2(0, 0);//new code --> i think this works for jumping with up on joystick, prevents from impulse force being built up
            playerRigidBody.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
            Debug.Log("jumped");
            //playerAnimator.SetBool("onGround", onGround);
            
        }

        onIce = Physics2D.OverlapCircle(groundPoint.position, groundRange, iceLayer);

        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        onStuck = Physics2D.OverlapCircle(groundPoint.position, groundRange, stuckLayer);

        if (onStuck)
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = /*10f*/ 13.45f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onStuck)
        {
            numPresses++;

            if (numPresses >= 3)
            {
                playerRigidBody.velocity = new Vector2(0, 0);//new code --> i think this works for jumping with up on joystick, prevents from impulse force being built up
                playerRigidBody.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
                Debug.Log("jumped");
                //playerAnimator.SetBool("onGround", onGround);

                numPresses = 0;
            }

            numPresses = Mathf.Clamp(numPresses, 0, 3);
        }
    }

    private void FixedUpdate()
    {
        moveHori = Input.GetAxisRaw("Horizontal");                                                   //movement using horizontal axis and rigidbody of gameobject
        //playerRigidBody.velocity = new Vector2(moveHori * moveSpeed, playerRigidBody.velocity.y);

        //playerRigidBody.AddForce(playerForce, ForceMode2D.Force);

        //playerAnimator.SetFloat("Speed", Mathf.Abs(moveHori));                                      //setting the speed parameter for when the movement animation needs to be called

        

        if (onIce)
        {
            playerRigidBody.AddForce(move * moveSpeed, ForceMode2D.Force);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(moveHori * moveSpeed, playerRigidBody.velocity.y);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (groundPoint == null)               //used to ensure no error is thrown when nothing is within the groundPoint range
        {
            return;
        }

        Gizmos.DrawWireSphere(groundPoint.position, groundRange); //visually display the overlapcircle in unity game scene
    }
}
