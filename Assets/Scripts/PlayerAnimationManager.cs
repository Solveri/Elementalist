using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    
    void Start()
    {
        
    }
    private void Awake()
    {

       
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveX",Mathf.Abs(InputManagers.instance.Movement.x));
        animator.SetInteger("Presses",InputManagers.instance.Presses);
        
        
        if (InputManagers.instance.HasPressedDash)
        {
            animator.SetTrigger("Roll");
        }
        if (InputManagers.instance.Movement.x > 0 && !InputManagers.instance.IsDoingAction )
        {
            this.transform.localScale = new Vector3(1,1,1);
        }
        else if (InputManagers.instance.Movement.x < 0 && !InputManagers.instance.IsDoingAction)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }
    public void ForceOutOfAttack()
    {
        animator.SetTrigger("ForceOut");
    }
    public void ChangeActionTrue()
    {
        InputManagers.instance.IsDoingAction = true;
    }
    public void ChangeActionFalse()
    {
        InputManagers.instance.IsDoingAction = false;
    }
    
}
