using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombat : MonoBehaviour
{
    public Animator playerAnimator;

    public Transform punchPoint;
    public float punchRange = 0.3f;
    public LayerMask enemyLayer;                         //using a layermask and assigned layers to detect the enemy

    public int attackDamage = 15;

    public static int numPresses = 0; //changed from public to public static so that numpresses can be accessed by movement script
    float lastTimePressed = 0;
    public float maxComboDelayTime = 1.2f;

    public Text hitCombo;

    public Animator enemyDamageAnimator;

    public Image twoHitComboImg;
    public Image threeHitComboImg;

    public Animator enemyReactionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        hitCombo.enabled = false;
        twoHitComboImg.enabled = false;
        threeHitComboImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastTimePressed > maxComboDelayTime)
        {
            numPresses = 0;
            /*playerAnimator.SetBool("1stHit", false);//new code//these 3 lines are the workaround
            playerAnimator.SetBool("2ndHit", false);//new code
            playerAnimator.SetBool("3rdHit", false);*///new code
            hitCombo.enabled = false;
            twoHitComboImg.enabled = false;
            threeHitComboImg.enabled = false;
        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && playerMovement.vertMovement < 0.5f && playerMovement.onGround)
        {
            lastTimePressed = Time.time;
            numPresses++;
            //numPresses++;
            
            if(numPresses == 1)
            {
                //Punch();
                attackDamage = 1;
                playerAnimator.SetTrigger("Punch");//new line of code//THIS WORKED!
                /*playerAnimator.SetBool("1stHit", true);*///this is the original line of code
                /*playerAnimator.SetBool("2ndHit", false);*///maybe put back in
                playerAnimator.SetBool("3rdHit", false);//this line attempts to fix the freezing bug when 3rdhit animation plays
                Punch();
            }
            //Punch();

            numPresses = Mathf.Clamp(numPresses, 0, 3);


        }

        
    }

    void Punch()
    {
        //play the punch animation
        //playerAnimator.SetTrigger("Punch");

        //play player punch sound
        FindObjectOfType<AudioManager>().Play("playerGrunt");

        //Detect enemy in range of attack
        Collider2D[] punchEnemy = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, enemyLayer);       //the array will detect any enemies that appear within the assigned range
                                                                                                                 //of the overlapcircle 
        //Damage Enemy
        foreach (Collider2D enemy in punchEnemy)
        {
            Debug.Log("punched enemy" + enemy.name);
            enemy.GetComponent<enemyHealth>().takeDamage(attackDamage);        //calls the enemyHealth script to decrease the health of the enemy
            if(numPresses == 2)
            {
                /*hitCombo.color = new Color(240.0f/255.0f, 208.0f/255.0f, 0.0f/255.0f);
                hitCombo.text = "2 HIT COMBO!";
                hitCombo.enabled = true;*/
                threeHitComboImg.enabled = false;
                twoHitComboImg.enabled = true;
            }

            if (numPresses >= 3)
            {
                /*hitCombo.color = new Color(240.0f / 255.0f, 140.0f / 255.0f, 0.0f / 255.0f);
                hitCombo.text = "3 HIT COMBO!";
                hitCombo.enabled = true;*/
                twoHitComboImg.enabled = false;
                threeHitComboImg.enabled = true;
            }

            if (numPresses==2)
            {
                enemyDamageAnimator.SetTrigger("2ndSpark");//new code
                enemyReactionAnimator.SetTrigger("2ndReaction");
            }

            switch (numPresses)
            {
                case 1:
                    enemyDamageAnimator.SetTrigger("1stSpark");
                    enemyReactionAnimator.SetTrigger("1stReaction");
                    break;
                /*case 2:
                    enemyDamageAnimator.SetTrigger("2ndSpark");
                    break;*/
                case 3:
                    enemyDamageAnimator.SetTrigger("3rdSpark");
                    enemyReactionAnimator.SetTrigger("3rdReaction");
                    break;
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)               //used to ensure no error is thrown when nothing is within the punchPoint range
        {
            return;
        }

        Gizmos.DrawWireSphere(punchPoint.position, punchRange); //visually display the overlapcircle in unity game scene
    }


    public void secondHit()
    {
        if(numPresses >= 2)
        {
            attackDamage = 2;
            playerAnimator.SetBool("2ndHit", true);
            Punch();
            //playerAnimator.SetBool("1stHit", false);//new code
            //hitCombo.text = "2 HIT COMBO!";
            //hitCombo.enabled = true;
        }
        else
        {
            playerAnimator.SetBool("1stHit", false);
            numPresses = 0;
        }
    }

    public void thirdHit()
    {
        if (numPresses >= 3)//original >= 
        {
            attackDamage = 5;
            playerAnimator.SetBool("3rdHit", true);
            Punch();
            playerAnimator.SetBool("1stHit", false);//bug fix --i think this works?
            //playerAnimator.SetBool("2ndHit", false);//new code
            //hitCombo.text = "3 HIT COMBO!";
            //hitCombo.enabled = true;
        }
        else
        {
            playerAnimator.SetBool("2ndHit", false);
            playerAnimator.SetBool("1stHit", false);//this line attempts to fix the freezing bug when 3rdhit animation plays
            numPresses = 0;
        }
    }

    public void resetHit()
    {
        playerAnimator.SetBool("1stHit", false);
        playerAnimator.SetBool("2ndHit", false);
        playerAnimator.SetBool("3rdHit", false);
        numPresses = 0;
    }

}
