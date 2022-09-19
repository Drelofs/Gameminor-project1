using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2;
    public float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(){
        //if (Time.time >= nextAttackTime)
        //{
            //Play an attack animation
            animator.SetTrigger("Attack");
            //Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            //Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("found enemy: " + enemy.gameObject.name, enemy.gameObject);
                if (enemy.TryGetComponent<Enemy>(out Enemy enemyScript))
                {
                    enemyScript.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
            }
        //}
        //nextAttackTime = Time.time + 1f / attackRate;
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("IsHurt");
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void OnDrawGizmosSelected() {

        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
