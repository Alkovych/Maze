using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRespHelper : NetworkBehaviour
{
    public Transform player;

    void Start () {

        Transform playerO = (Transform) Network.Instantiate(player, transform.position+new Vector3(Random.Range(0,2),0, Random.Range(0, 2)), transform.rotation, 0);
        playerO.transform.GetComponentInChildren<Camera>().GetComponent<Camera>().enabled = true;
    }
	
	void Update () {

    }

}


