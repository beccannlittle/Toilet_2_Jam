using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shia : MonoBehaviour {

    public float speed = 5f;
    public Player player;

    private Rigidbody2D rb { get; set; }
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponentInChildren<Animator>();
        player.playerDied += DoVictory;
    }

    private bool isStopped;

    private void FixedUpdate()
    {
        if (!isStopped)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    private void DoVictory()
    {
        isStopped = true;
        rb.velocity = new Vector2(0f, 0f);
        anim.SetTrigger("Stopped");
    }
}
