using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    private bool canAttack;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            canAttack = true;
        }
    }

    public void Attack(){
        if (canAttack)
        {
            //Play an attack animation
            animator.SetTrigger("Attack");
            //Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            //Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                //Debug.Log("found enemy: " + enemy.gameObject.name, enemy.gameObject);
                if (enemy.TryGetComponent<Enemy>(out Enemy enemyScript))
                {
                    enemyScript.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
            }
            nextAttackTime = Time.time + 1f / attackRate;
            canAttack = false;
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("IsHurt");
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Debug.Log("Player died!");
        SceneManager.LoadScene("Deathscreen", LoadSceneMode.Single);

    }

    void OnDrawGizmosSelected() {

        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
