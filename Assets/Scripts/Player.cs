using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpStrength;
    
    public Collider2D GroundCollider;
    public bool grounded;
    public Animator animator;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        
        //jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            
        }
        animator.SetFloat("xmove", Mathf.Abs(rb.velocity.x));
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = false;
        animator.SetBool("Jump", false);

    }
}
