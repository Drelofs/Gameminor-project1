using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Public Variables
    public GameObject player;
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum istance to attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Animator anim;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private PlayerCombat playerCombat;
    private bool isDone = false;

    #endregion

    void Awake()
    {
        intTimer = timer;
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, -rayCast.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        //When Player is detected
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            if (!isDone)
            {
                StartCoroutine(Attack(0.35f));
                isDone = true;
            }

        }

        if (cooling)
        {
            Cooldown();
            isDone = false;
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
    }

    IEnumerator Attack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerCombat = player.GetComponent<PlayerCombat>();
        playerCombat.TakeDamage(20);
        timer = intTimer; // Reset time when player enters attack Range
        attackMode = true; // To check if enemy can still attack or not

        anim.SetTrigger("Attack");
        anim.SetBool("canWalk", false);
        TriggerCooling();
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <=0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
