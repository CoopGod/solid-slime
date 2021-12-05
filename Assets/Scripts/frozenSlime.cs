using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenSlime : MonoBehaviour
{
    // Global Variables
    public GameObject playerPrefab;
    GameObject spawnLocation;
    public int currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = GameObject.Find("SpawnLocation");
        Instantiate(playerPrefab, spawnLocation.transform.position, Quaternion.identity);
        GameObject.Find("Player(Clone)").GetComponent<player>().jumpAmmo = currentAmmo; // moves ammo onto next player
    }
}
