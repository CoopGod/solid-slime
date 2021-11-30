using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    // Global Variables
    GameObject Player;

    // To initilize Player variable
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update if players 'feet' are on the ground
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            Player.GetComponent<player>().isGrounded = true;
        }
    }

    // Update if players 'feet' are off the ground
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            Player.GetComponent<player>().isGrounded = false;
        }
    }
}
