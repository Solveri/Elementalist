using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveX",Mathf.Abs(InputManagers.instance.Movement.x));
        if (InputManagers.instance.HasPressedDash)
        {
            animator.SetTrigger("Roll");
        }
        if (InputManagers.instance.Movement.x > 0 )
        {
            this.transform.localScale = new Vector3(1,1,1);
        }
        else if (InputManagers.instance.Movement.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }
}
