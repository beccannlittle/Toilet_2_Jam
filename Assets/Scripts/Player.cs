using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 300f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float waitUntilRun;
    public float gravitationalModifer;

    public delegate void PlayerDiedDelegate();
    public PlayerDiedDelegate playerDied;

    public delegate void PlayerWonDelegate();
    public PlayerWonDelegate playerWon;

    private bool dead = false;
    private bool attack = false;
    private bool grounded = false;
    private float groundRadius = 0.2f;

    private Rigidbody2D rb { get; set; }
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponentInChildren<Animator>();
        Invoke("StartRunning", waitUntilRun);
    }

    private bool isStarted;

    private void StartRunning()
    {
        isStarted = true;
        anim.SetTrigger("StartRunning");
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        if (isStarted)
        {
            if (!grounded)
            {
                anim.SetFloat("vSpeed", rb.velocity.y);
            }
            if (!dead && !attack)
            {
                rb.gravityScale = rb.velocity.y < 0 ? gravitationalModifer : 1;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

    }

    private void HandleInput()
    {
        // Jumping 
        if (grounded && Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        // Attacking
        //if (Input.GetKeyDown(KeyCode.LeftAlt) && !dead)
        //{
        //    attack = true;
        //    anim.SetBool("Attack", true);
        //    anim.SetFloat("Speed", 0);

        //}
        //if (Input.GetKeyUp(KeyCode.LeftAlt))
        //{
        //    attack = false;
        //    anim.SetBool("Attack", false);
        //}

        // Dead animation for testing
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    if (!dead)
        //    {
                
        //    }
        //    else
        //    {
        //        anim.SetBool("Dead", false);
        //        dead = false;
        //    }
        //}
    }

    public void Die()
    {
        if (playerDied != null)
        {
            playerDied();
        }
        rb.velocity = new Vector2(0f, 0f);
        anim.SetBool("Dead", true);
        dead = true;
    }

    public void Win()
    {
        if (playerWon != null)
        {
            playerWon();
        }
        anim.SetTrigger("CelebrateThenStand");
        isStarted = false;
        rb.velocity = new Vector2(0f, 0f);
    }
}
