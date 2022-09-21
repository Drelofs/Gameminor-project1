using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public SpriteRenderer spriteRenderer;

    //[SerializeField] SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            //spriteRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            //spriteRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
