using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowflakeSpawner : MonoBehaviour
{
    // Global Variables
    public GameObject snowflakePrefab;
    public GameObject spawnLocation;
    int jumpAmmo;
    public int snowflakeSpawns;

    // Update is called once per frame
    void Update()
    {
        // if freezing, drop flakes
        if (Input.GetButtonDown("Shift"))
        {
            jumpAmmo = GameObject.Find("gameController").GetComponent<gameController>().jumpCount;
            if (jumpAmmo > 0)
            {
                for (int i = 0; i < snowflakeSpawns; i += 1)
                {
                    Instantiate(snowflakePrefab, new Vector3(Random.Range(spawnLocation.transform.position.x - 15, spawnLocation.transform.position.x + 15), spawnLocation.transform.position.y + 15, 2), Quaternion.identity);
                }
            }
        }
    }
}
