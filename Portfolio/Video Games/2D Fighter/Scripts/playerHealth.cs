using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Text heroHealth;

    public int maxHealth = 200;
    int currentHealth;

    public heathBarScript healthBar;

    public GameObject playerEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        heroHealth.text = "Hero Health: " + currentHealth.ToString();
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.setHealth(currentHealth);

        Instantiate(playerEffect, transform.position, Quaternion.identity);

        //play hit player sound
        FindObjectOfType<AudioManager>().Play("hitPlayer");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("hero died");
        currentHealth = 0;
    }
}
