using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    //[SerializeField] SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
