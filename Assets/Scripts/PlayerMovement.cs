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
        onGround = Physics2D.BoxCast(JumpPoint.position, new Vector2(0.3511701f, 0.06263132f), 0, Vector2.down, 0.1f, ground);
    }
    private void FixedUpdate()
    {
        if (InputManagers.instance.Movement != Vector2.zero && onGround)
        {
            
            Vector2 movement =  InputManagers.instance.Movement*speed*Time.deltaTime;
             movement.x =  Mathf.Round(movement.x);
            rb.velocity = movement;
            

        }
        else
        {
            rb.velocity = new Vector2 (rb.velocity.x,rb.velocity.y);
        }

        if(InputManagers.instance.CanJump && onGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(InputManagers.instance.ResetJump());
        }
        if (InputManagers.instance.Movement == Vector2.zero)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
