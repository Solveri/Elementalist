using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    [SerializeField]private float speed = 50f;
    [SerializeField]private float jumpForce = 100f;
    [SerializeField] private Transform JumpPoint;
    [SerializeField] private LayerMask ground;
    [SerializeField]bool onGround;
    
    InputManagers inputManager;
    [SerializeField]Collider2D legs;

   [SerializeField]private bool canDash;
    private bool isDashing;
    
    [SerializeField]private float dashPower = 200f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManagers.instance;
        canDash = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        onGround = isGrounded();
        if (canDash && inputManager.HasPressedDash)
        {
                StartCoroutine(Dash());
        }
        if (InputManagers.instance.Movement.y == -1 && InputManagers.instance.CanJump)
        {
            
            
            if (isGrounded().transform.tag == "PassableGround")
            {
            legs.isTrigger = true;
                StartCoroutine(RestColider(legs));

            }
            
        }
      
            
            
       

        
    }
    private Collider2D isGrounded()
    {
        return Physics2D.OverlapCircle(JumpPoint.position, 0.2f, ground);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(JumpPoint.position, 0.2f, ground);
    }
    private IEnumerator RestColider(Collider2D cd)
    {
        yield return new WaitForSeconds(1f);
        cd.isTrigger = false;

    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
       
        if (InputManagers.instance.Movement != Vector2.zero && onGround && !InputManagers.instance.IsDoingAction)
        {
            
            Vector2 movement =  InputManagers.instance.Movement*speed*Time.deltaTime;
             movement.x =  Mathf.Round(movement.x);
            rb.velocity = movement;
            

        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }

        if (InputManagers.instance.CanJump && onGround && InputManagers.instance.Movement.y >=0)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(InputManagers.instance.ResetJump());
        }
        if (InputManagers.instance.Movement == Vector2.zero)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
       inputManager.HasPressedDash = false;
        isDashing = true;
        float originalGrav = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(inputManager.Movement.x*dashPower,0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGrav;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash= true;
        
        
    }
}

