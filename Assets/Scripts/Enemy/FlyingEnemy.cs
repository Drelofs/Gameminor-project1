using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public GameObject player;
    public GameObject spawner;
    public Animator anim;


    private PlayerCombat playerCombat;
    void Start()
    {
        currentHealth = maxHealth;
        GetComponent<AIPath>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (spawner && spawner.GetComponent<EnemySpawner>().playerDetected)
        {
            Debug.Log("Enemy Spawning!");
            //gameObject.SetActive(true);
            GetComponent<AIPath>().enabled = true;
            if (spawner != null)
            {
                Destroy(spawner.gameObject);
            }
        }
    }

    IEnumerator Attack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerCombat = player.GetComponent<PlayerCombat>();
        playerCombat.TakeDamage(20);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("Attacking player!");
            StartCoroutine(Attack(0.3f));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        //anim.SetBool("isHit", true);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        this.enabled = false;

        //GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("IsDead");
        GetComponent<AIPath>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<FlyingEnemy>().enabled = false;
        //GetComponentInChildren<SpriteRenderer>().enabled = false;

    }
}
