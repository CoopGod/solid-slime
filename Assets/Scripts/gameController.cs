using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

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

    public PostProcessVolume volume;
    ColorGrading cg;

    // Change text sixe to reflect how large the screen is
    void Start()
    {
        jumpCounter.GetComponent<Text>().fontSize = Screen.width / 100 * 12;
        freezeText.fontSize = Screen.width / 100 * 10;
        volume.profile.TryGetSettings(out cg);
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
            // post process a cooler look
            cg.temperature.value -= 30 * Time.deltaTime;

            if (freezeText.color.a >= 1)
            {
                freezeTextUp = false;
                freezeTextDown = true;
            }
        }
        if (freezeTextDown)
        {
            // change text transparency
            lightBlue.a = lightBlue.a - 0.9f * Time.deltaTime;
            freezeText.color = lightBlue;
            // post process back to a warmer look
            cg.temperature.value += 30 * Time.deltaTime;

            if (freezeText.color.a <= 0)
            {
                freezeTextDown = false;
                cg.temperature.value = 0;
            }
        }
        // when freeze is clicked too quickly the text and post process will not fade, this combats it
        if (!freezeTextDown && !freezeTextUp)
        {
            if (freezeText.color.a > 0)
            {
                lightBlue.a = 0;
                freezeText.color = lightBlue;
            }
            if (cg.temperature.value < 0)
            {
                cg.temperature.value = 0;
            }
        }

        // restart current level when reset button is pressed
        if (Input.GetButtonDown("Reset"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
