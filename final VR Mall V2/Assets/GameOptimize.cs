using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptimize : MonoBehaviour {
    public GameObject fristFloor,secondFloor,SecondRoof;
	// Use this for initialization
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (fristFloor.activeSelf)
            {
                fristFloor.SetActive(false);
                secondFloor.SetActive(true);
                SecondRoof.SetActive(true);
            }
            else if(!fristFloor.activeSelf)
            {
                fristFloor.SetActive(true);
                secondFloor.SetActive(false);
                SecondRoof.SetActive(false);
            }


        }
    }

}
