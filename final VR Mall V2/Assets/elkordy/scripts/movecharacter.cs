using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecharacter : MonoBehaviour
{
    GameObject Player;
    GameObject stairs;
    CharacterController charch_controler;
    AutoWalk autowalk;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        stairs = GameObject.FindGameObjectWithTag("stairs");
        charch_controler = Player.GetComponent<CharacterController>();
        autowalk = Player.GetComponent<AutoWalk>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            Player.transform.SetParent(Player.transform, true);
            // Player.transform.parent = stairs.transform;

            charch_controler.enabled = true;
            autowalk.enabled = true;
            print("Exit");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.transform.SetParent(stairs.transform, true);
           // Player.transform.parent = stairs.transform;
           
            charch_controler.enabled = false;
            autowalk.enabled = false;
            print("Enter");
        }


    }
}
