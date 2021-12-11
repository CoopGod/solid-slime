using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowflakeFaller : MonoBehaviour
{
    // Global Variables
    public float speedMax;
    public float speedMin;
    float speed;
    float initY;

    // Play on first frame
    void Start()
    {
        // get random speed
        speed = Random.Range(speedMin, speedMax);
        // init current y value
        initY = transform.position.y;
        // get random size
        float newScale = Random.Range(2.3f, 4);
        transform.localScale = new Vector3(newScale, newScale, 1);
        // get random rotation
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // send flakes downwards
        Vector3 movement = new Vector3(0f, -1f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        // destroy flake if too far down
        if (transform.position.y < initY - 30)
        {
            Destroy(gameObject);
        }
    }
}
