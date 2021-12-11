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
    public AudioSource iceSound;

    bool freezeTextUp = false;
    bool freezeTextDown = false;
    public Text freezeText;
    public Color lightBlue;

    // Change text sixe to reflect how large the screen is
    void Start()
    {
        jumpCounter.GetComponent<Text>().fontSize = Screen.width / 100 * 12;
    }
    
    void Update()
    {
        // Check if jumpCount has been changed, if it has update the jump Counter on the HUD
        if (previousCount != jumpCount)
        {
            jumpCounter.GetComponent<Text>().text = jumpCount.ToString();
            if (previousCount > jumpCount) // if jumpCount decreases/ player freezes, play sound
            {
                iceSound.Play();
                freezeTextUp = true;
            }
            previousCount = jumpCount;
        }

        // go from transparent to opaque and back down for the frozen text
        if (freezeTextUp)
        {   
            lightBlue.a = lightBlue.a + 0.9f * Time.deltaTime;
            freezeText.color = lightBlue;
            Debug.Log(freezeText.color.a);
            if (freezeText.color.a >= 1)
            {
                freezeTextUp = false;
                freezeTextDown = true;
            }
        }
        if (freezeTextDown)
        {
            lightBlue.a = lightBlue.a - 0.9f * Time.deltaTime;
            freezeText.color = lightBlue;
            if (freezeText.color.a <= 0)
            {
                freezeTextDown = false;
            }
        }
    }
}
