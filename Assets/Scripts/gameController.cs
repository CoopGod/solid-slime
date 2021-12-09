using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    // Global variables
    public int jumpCount = 2;
    int previousCount = 0;
    public GameObject jumpCounter;

    // Change text sixe to reflect how large the screen is
    void Start()
    {
        jumpCounter.GetComponent<Text>().fontSize = Screen.width / 100 * 12;
    }

    // Check if jumpCount has been changed, if it has update the jump Counter on the HUD
    void Update()
    {
        if (previousCount != jumpCount)
        {
            jumpCounter.GetComponent<Text>().text = jumpCount.ToString();
            previousCount = jumpCount;
        }
    }
}
