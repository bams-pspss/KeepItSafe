using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CatController : MonoBehaviour
{
    //CharacterController characterController;
    Animator animator;
    Rigidbody2D rb;
    private Vector3 origiSc; 
    private Vector2 moveDir = Vector2.zero;
    private bool isGrounded = true;
    private bool canRest = false;

    public float moveSpeed = 6f;
    public float jumpSpeed = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        origiSc = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float horiInput = Input.GetAxisRaw("Horizontal");
        //float vertiInput = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(horiInput * moveSpeed, rb.velocity.y);
        

        animator.SetBool("Walk", horiInput != 0);

        //Going to the left
        if (horiInput < 0) 
        {
            //Flip thre character!
            transform.localScale = new Vector3(-origiSc.x, origiSc.y,origiSc.z);
            animator.SetBool("Rest", false);
            
        }
        //Going to the right
        else if (horiInput > 0)
        {
            transform.localScale = new Vector3(origiSc.x, origiSc.y,origiSc.z);
            animator.SetBool("Rest", false);
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            print("JUMP BITCH");
            animator.SetBool("Rest", false);
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            //moveSpeed = 10;
            animator.SetBool("Run", true);
        }
    
        animator.SetFloat("Jumping", rb.velocity.y);
        
        if(canRest){
            //Show the popup key that can press X;
            //Can rest but cannot get up
            if(Input.GetKeyDown("x")){
                print("resting");
                animator.SetBool("Rest", canRest);
            }

        }
    }


   

    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        isGrounded = false;
        // animator.SetBool("isJumping", false);
        print($"Is Grounded {isGrounded}");
    }

     void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.velocity = new Vector2(moveDir.x, rb.velocity.y);
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Rest"))
        {
            print("Resting box!");
            canRest = true;

        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Rest"))
        {
            print("It landed");
            isGrounded = true; 
            
            animator.SetBool("isGrounded", isGrounded);

        }
    }
}
