using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieByFalling : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.transform.parent.GetComponent<Player>();
            player.Die();
        }
    }
}
