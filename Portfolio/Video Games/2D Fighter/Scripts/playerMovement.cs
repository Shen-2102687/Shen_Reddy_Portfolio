using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator playerAnimator;

    public Rigidbody2D playerRigidBody;

    float moveHori = 0f;
    public float moveSpeed = 20f;

    float jumpHeight = 6f;

    public static bool onGround; //was private bool, now pub static so can be accessed in combat script
    public Transform groundPoint;
    public float groundRange = 0.3f;
    public LayerMask groundLayer;

    public GameObject enemyObject;
    float switchPosition;

    public static float vertMovement;

    // Start is called before the first frame update
    void Start()
    {

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
        playerAnimator.SetBool("onGround", onGround);

        if (onGround && /*Input.GetKeyDown(KeyCode.Y)*/ /*Input.GetAxisRaw("Vertical")>=0.5f*/ vertMovement>=0.5f && playerCombat.numPresses < 1)
        {
            playerRigidBody.velocity = new Vector2(0, 0);//new code --> i think this works for jumping with up on joystick, prevents from impulse force being built up
            playerRigidBody.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
            Debug.Log("jumped");
            //playerAnimator.SetBool("onGround", onGround);
        }

        

        if (enemyObject.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            enemyObject.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            enemyObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        }


    }

    private void FixedUpdate()
    {
        moveHori = Input.GetAxisRaw("Horizontal");                                                   //movement using horizontal axis and rigidbody of gameobject
        playerRigidBody.velocity = new Vector2(moveHori * moveSpeed, playerRigidBody.velocity.y);

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveHori));                                      //setting the speed parameter for when the movement animation needs to be called
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
