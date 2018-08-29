using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;
using UnityEngine.UI;

public class CinemaP : MonoBehaviour {
    public GameObject Player;
    public Button bttn;
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bttn.GetComponent<Button>().interactable = true;
         Player.GetComponent<AutoWalk>().enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = false;
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<NavMeshAgent>().enabled = false;
            Player.GetComponent<NavAgentExample>().enabled = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Player.GetComponent<FirstPersonController>().enabled = true;
        //Player.GetComponent<CharacterController>().enabled = true;
        //Player.GetComponent<NavMeshAgent>().enabled = false;
        //Player.GetComponent<NavAgentExample>().enabled = false;
    }
}
