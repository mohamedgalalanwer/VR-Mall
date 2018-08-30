using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entery1 : MonoBehaviour {

    GameObject Player;
    GameObject stairs2;
    CharacterController charch_controler;
    AutoWalk autowalk;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        stairs2 = GameObject.Find("stairs2");
        charch_controler = Player.GetComponent<CharacterController>();
        autowalk = Player.GetComponent<AutoWalk>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.SetParent(stairs2.transform, true);
           // Debug.Log("player is on ");
           Player.GetComponent<CharacterController>().enabled = false;
            // Player.transform.parent = stairs.transform;

           // charch_controler.enabled = false;
            //autowalk.enabled = false;
            print("Enter");
        }


    }
}
