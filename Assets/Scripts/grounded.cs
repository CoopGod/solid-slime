using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    // Global Variables
    GameObject Player;
    Animator animator;

    // To initilize Player variable
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        animator = Player.GetComponent<Animator>();
    }

    // Update if players 'feet' are on the ground
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player.GetComponent<player>().isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    // Update if players 'feet' are off the ground
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player.GetComponent<player>().isGrounded = false;
        }
    }
}
