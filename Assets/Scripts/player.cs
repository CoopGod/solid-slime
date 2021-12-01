using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Global Variables
    public float playerSpeed;
    public float playerJumpMultiplier;
    float jumpTimeCounter;
    public float jumpTime = 0.35f;
    public bool isGrounded = true; // is gathered from the grounded.cs script
    bool hasJumped = false;
    public GameObject frozenSlime; 
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * playerSpeed;
        Jump();
        Freeze();
    }

    // Self explanitory
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * (playerJumpMultiplier -0.5f);
            jumpTimeCounter = jumpTime;
            hasJumped = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            hasJumped = false;
        }

        if (Input.GetKey(KeyCode.Space) && hasJumped)
        {
            Debug.Log(jumpTimeCounter);
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * playerJumpMultiplier;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                hasJumped = false;
            }
        }
    }

    // When 'Shift' is pressed. swap positions with frozen prefab
    void Freeze()
    {
        if (Input.GetButtonDown("Shift"))
        {
            Instantiate(frozenSlime, gameObject.transform.position, Quaternion.identity); // instantiate at current location
            Destroy(gameObject);
        }
    }
}
