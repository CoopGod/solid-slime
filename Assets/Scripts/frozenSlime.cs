using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenSlime : MonoBehaviour
{
    // Global Variables
    public GameObject playerPrefab;
    GameObject spawnLocation;
    Animator animator;
    int triggerTime;
    bool triggerSet = false;
    float currentTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        spawnLocation = GameObject.Find("SpawnLocation");
        Instantiate(playerPrefab, spawnLocation.transform.position, Quaternion.identity);
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // randomly trigger the sheen animation
        if (!triggerSet)
        {   
            triggerTime = Random.Range(5, 10);
            triggerSet = true;
        }
        currentTime += Time.deltaTime;
        if ((int)(currentTime % 60) == triggerTime) // if seconds line up. play animation (makes it random but frequent)
        {
            animator.SetTrigger("sheen");
            triggerSet = false;
            currentTime = 0f; // reset time
        }
        
    }
}
