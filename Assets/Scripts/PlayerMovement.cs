using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    private float speed = 5f;
    
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
        
    }
    private void FixedUpdate()
    {
        if (InputManagers.instance.Movement != Vector2.zero)
        {
            
            rb.velocity += InputManagers.instance.Movement*speed*Time.deltaTime;
        }
    }
}
