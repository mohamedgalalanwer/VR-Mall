using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entery : MonoBehaviour {

    GameObject Player;
    GameObject stairs;
    AutoWalk autowalk;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        stairs = GameObject.Find("stairs");
        autowalk = Player.GetComponent<AutoWalk>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.SetParent(stairs.transform, true);
           Player.GetComponent<CharacterController>().enabled = false;
            autowalk.enabled = false;
            print("Enter");
        }


    }
}
