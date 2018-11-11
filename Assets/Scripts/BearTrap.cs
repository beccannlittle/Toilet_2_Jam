using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour {

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Trapped");
            var player = other.gameObject.transform.parent.GetComponent<Player>();
            gameObject.transform.position = player.groundCheck.position;
            gameObject.transform.rotation = player.groundCheck.rotation;
            player.Die();
        }
    }
}
