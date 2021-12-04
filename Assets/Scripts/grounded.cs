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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player.GetComponent<player>().isGrounded = true;
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
