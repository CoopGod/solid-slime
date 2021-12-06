using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenSlime : MonoBehaviour
{
    // Global Variables
    public GameObject playerPrefab;
    GameObject spawnLocation;

    // Start is called before the first frame update
    void Awake()
    {
        spawnLocation = GameObject.Find("SpawnLocation");
        Instantiate(playerPrefab, spawnLocation.transform.position, Quaternion.identity);
    }
}
