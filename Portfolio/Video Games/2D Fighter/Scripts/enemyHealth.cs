using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public Text enemyText;

    public int maxHealth = 100;
    int currentHealth;

    public GameObject enemyEffect;

    public heathBarScript enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        enemyText.text = "Enemy health: " + currentHealth.ToString();
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        enemyHealthBar.setHealth(currentHealth);

        //Instantiate(enemyEffect, this.transform.position, Quaternion.identity);
        /*if (playerCombat.numPresses == 3)
        {
            Instantiate(enemyEffect, this.transform.position, Quaternion.identity);
        }*/

        //play sound
        FindObjectOfType<AudioManager>().Play("hitEnemy");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died");
        currentHealth = 0;
    }
}
