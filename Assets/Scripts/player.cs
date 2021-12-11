using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Global Variables
    public int jumpAmmo = -1;
    public float playerSpeed;
    public float playerJumpMultiplier;
    float jumpTimeCounter;
    public float jumpTime = 0.35f;
    public bool isGrounded = true; // is gathered from the grounded.cs script
    bool hasJumped = false;
    public GameObject frozenSlime; 
    Rigidbody2D rb;
    Animator animator;
    AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        jumpSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // get jump count if none yet
        if (jumpAmmo < 0)
        {
            jumpAmmo = GameObject.Find("gameController").GetComponent<gameController>().jumpCount;
        }
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
            animator.SetBool("isJumping", true);
            jumpSound.Play(); // play jumping noise
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            hasJumped = false;
        }

        if (Input.GetKey(KeyCode.Space) && hasJumped)
        {
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

    // When 'Shift' is pressed. swap positions with frozen prefab provided you have the resources
    void Freeze()
    {
        if (Input.GetButtonDown("Shift"))
        {
            if (jumpAmmo > 0)
            {
                GameObject.Find("gameController").GetComponent<gameController>().jumpCount -= 1;
                Instantiate(frozenSlime, gameObject.transform.position, Quaternion.identity); // instantiate at current location
                Destroy(gameObject);
            }
        }
    }
}
