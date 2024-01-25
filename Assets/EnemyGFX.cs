using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aipath;
    [SerializeField] Animator animator;
    [SerializeField] EnemyAI enemyAI;
    [SerializeField] Rigidbody2D rigidbody2;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("EnemyX",Mathf.Abs(rigidbody2.velocity.x));
        
        if (enemyAI.dir.x >= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (enemyAI.dir.x >=  -0.01f) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (enemyAI.hasReachedTarget)
        {
            animator.SetTrigger("FistAttack");
        }
    }
    
}
