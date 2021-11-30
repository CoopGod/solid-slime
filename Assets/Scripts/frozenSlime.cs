using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenSlime : MonoBehaviour
{
    // Global Variables
    public GameObject playerPrefab;
    public float spawnLocationX = -3;
    public float spawnLocationY = -1;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, new Vector3(spawnLocationX, spawnLocationY, 0), Quaternion.identity);
    }
}
