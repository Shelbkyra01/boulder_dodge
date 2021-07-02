using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    bool canMove = true; 
    
    [SerializeField] 
    float moveSpeed;

    Rigidbody2D rb;
    
    bool jumping = false;
    bool isGrounded;
    public LayerMask groundLayer;

    private float posZ;

    public float jumpForce;
    bool canDoubleJump;
    public Transform groundCheck;

    public static PlayerController instance;

    
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }

        if (Input.GetButtonDown ("Jump"))
        {
            if (isGrounded)
            {
                Jump();

                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                jumpForce = jumpForce / 2;

                Jump();

                canDoubleJump = false;

                jumpForce = jumpForce * 2;
            }
           
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        

    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;        
    }

  
    private void Jump()
    {
       rb.AddForce(Vector3.up * jumpForce);
    }

  

}