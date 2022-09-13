using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        //Play hurt animation

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){

        Debug.Log("Enemy died!");
        //Die animation

        //Disable the enemy
        //GetComponent<Collider2D>().enabled = false;
        GetComponent <AIPath>().enabled = false;
        this.enabled = false;

    }
}
