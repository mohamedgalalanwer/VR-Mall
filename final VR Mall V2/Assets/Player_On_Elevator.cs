using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_On_Elevator : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player is on ");
            Player.GetComponent<CharacterController>().enabled = false;
        }
	}
	
	// Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player is off ");
            Player.GetComponent<CharacterController>().enabled = true;
        }
	}
}
