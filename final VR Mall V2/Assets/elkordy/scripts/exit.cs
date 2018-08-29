using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {
    GameObject Player;
    GameObject stairs;
    CharacterController charch_controler;
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
            Player.transform.SetParent(null, true);
          Player.GetComponent<CharacterController>().enabled = true;
            autowalk.enabled = true;
            print("Exit");
        }
    }
}
