using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraHelper : MonoBehaviour
{
    //Global Variables
    public CinemachineVirtualCamera cam;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.Follow == null)
        {
            player = GameObject.Find("Player(Clone)");
        }
        cam.Follow = player.transform;
        cam.LookAt = player.transform;
    }
}
