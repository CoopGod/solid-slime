using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    // Global Variables
    GameObject spawnLocation;
    bool scaleUp = true;
    public Vector3 increase;
    Vector3 maxScale;
    Vector3 minScale;

    // To init spawn location and others
    void Start()
    {
        spawnLocation = GameObject.Find("SpawnLocation");
        maxScale = new Vector3(0.2f, 0.25f, 0);
        minScale = new Vector3(-0.2f, 0.25f, 0);
    }

    // Rotate checkpoint like a flag from sonic (because cool)
    void Update()
    {
        if (scaleUp)
        {
            gameObject.transform.localScale += increase;
            if (transform.localScale.x >= maxScale.x)
            {
                scaleUp = false;
            }
        }
        if (!scaleUp)
        {
            transform.localScale -= increase;
            if (transform.localScale.x <= minScale.x)
            {
                scaleUp = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player_check")
        {
            spawnLocation.transform.position = transform.position;
        }
    }
}