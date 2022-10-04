using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Animator anim;
    int currentHealth;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GetComponent<AIPath>().enabled = false;
        GetComponent<EnemyBehaviour>().enabled = false;
    }

    void Update()
    {
        if (spawner && spawner.GetComponent<EnemySpawner>().playerDetected)
        {
            Debug.Log("Enemy Spawning!");
            GetComponent<AIPath>().enabled = true;
            GetComponent<EnemyBehaviour>().enabled = true;
            if(spawner != null)
            {
                Destroy(spawner.gameObject);
            }
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        //Play hurt animation
        anim.SetTrigger("isHit");
        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){

        Debug.Log("Enemy died!");
        //Die animation
        anim.SetTrigger("isDead");
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        GetComponent<EnemyBehaviour>().enabled = false;

    }
}
