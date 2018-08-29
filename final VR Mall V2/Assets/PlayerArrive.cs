using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;
public class PlayerArrive : MonoBehaviour {
    public GameObject Player, enterStair1, enterStair2, exitStair1, exitStair2;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Player.GetComponent<AutoWalk>().enabled = true;
            Player.GetComponent<FirstPersonController>().enabled = true;
            Player.GetComponent<CharacterController>().enabled = true;
            Player.GetComponent<NavMeshAgent>().enabled = false;
            Player.GetComponent<NavAgentExample>().enabled = false;
            enterStair1.SetActive(true);
            enterStair2.SetActive(true);
            exitStair1.SetActive(true);
            exitStair2.SetActive(true);
        }
    }
}
