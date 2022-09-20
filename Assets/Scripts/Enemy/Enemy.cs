using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Animator anim;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        //Play hurt animation
        anim.SetBool("isHit", true);
        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){

        Debug.Log("Enemy died!");
        //Die animation
        anim.SetBool("isDead", true);
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent <AIPath>().enabled = false;
        GetComponent<EnemyBehaviour>().enabled = false;

    }
}
