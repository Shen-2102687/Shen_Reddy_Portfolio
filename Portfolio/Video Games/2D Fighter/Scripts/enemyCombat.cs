using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{
    public Animator enemyAnimator;

    public Transform punchPoint;
    public float punchRange = 0.3f;
    public LayerMask heroLayer;                        //using a layermask and assigned layers to detect the player

    public int attackDamage = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            Punch();
        }*/
    }

    void Punch()
    {
        //play enemy hit animation
        enemyAnimator.SetTrigger("Hit");

        //Detect enemy in range of attack
        Collider2D[] punchHero = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, heroLayer);  //the array will detect when the player appears within the assigned range

        //Damage Enemy
        foreach (Collider2D hero in punchHero)
        {
            Debug.Log("punched hero" + hero.name);
            hero.GetComponent<playerHealth>().takeDamage(attackDamage);     //calls the playerHealth script to decrease player health
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)       //used to ensure no error is thrown when nothing is within the punchPoint range
        {
            return;
        }

        Gizmos.DrawWireSphere(punchPoint.position, punchRange);    //visually display the overlapcircle in unity game scene
    }

}
