﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speedX;
    public float jumpSpeedY;

    private bool facingRight = true;
    private bool goingRight = true;
    private bool isJumping = false;
    private bool isDead = false;

    //private Animator anim;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.getInstance().debug)
        {
            isDead = false;
        }

        if (!isDead)
        {
            float x;

            // To prevent moonwalking
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                x = 0;
            }
            else
            {
                x = Input.GetAxis("Horizontal") * Time.deltaTime * speedX * 100;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                goingRight = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                goingRight = true;
            }

            // Move the player
            rb.velocity = new Vector3(x, rb.velocity.y, 0);
            
            // Jump
            if (!isJumping && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                isJumping = true;
                //SfxManager.PlaySound("jump");
                //anim.SetBool("isJumping", true);
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeedY, 0);
            }

            // add fake gravity to land faster
            if (isJumping)
            {
                Vector3 vel = rb.velocity;
                vel.y -= 15 * Time.deltaTime;
                rb.velocity = vel;
            }

            //if (rb.velocity.x != 0)
            //{
            //    anim.SetBool("isRunning", true);
            //}
            //else
            //{
            //    anim.SetBool("isRunning", false);
            //}

            // Flip
            if (goingRight && !facingRight || !goingRight && facingRight)
            {
                facingRight = !facingRight;
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // for jump
        if (isJumping && collision.gameObject.tag == "Ground" && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector3(0, 0, 0);
            isJumping = false;
            //anim.SetBool("isJumping", false);
        }
    }
}