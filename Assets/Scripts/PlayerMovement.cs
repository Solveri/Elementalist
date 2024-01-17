using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    [SerializeField]private float speed = 50f;
    [SerializeField]private float jumpForce = 100f;
    [SerializeField] private Transform JumpPoint;
    [SerializeField] private LayerMask ground;
    [SerializeField]bool onGround;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // onGround = Physics2D.CircleCast(JumpPoint.position,10,Vector2.down,2,ground);
        //onGround = Physics2D.OverlapBox(JumpPoint.position,new Vector2(5,5),0,ground);
        onGround = Physics2D.OverlapCapsule(JumpPoint.position, new Vector2(1.61f, 0.43f), CapsuleDirection2D.Horizontal, 0, ground);
    }
    private void FixedUpdate()
    {
        if (InputManagers.instance.Movement != Vector2.zero)
        {
            
            Vector2 movement =  InputManagers.instance.Movement*speed*Time.deltaTime;
             movement.x =  Mathf.Round(movement.x);
            rb.velocity = movement;
            

        }
        else
        {
            rb.velocity = new Vector2 (0,rb.velocity.y);
        }

        if(InputManagers.instance.CanJump && onGround)
        {
           
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce)*Time.deltaTime;
            StartCoroutine(InputManagers.instance.ResetJump());
        }
    }
}
