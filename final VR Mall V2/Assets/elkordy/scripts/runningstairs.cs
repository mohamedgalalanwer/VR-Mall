using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningstairs : MonoBehaviour
{

    GameObject x;
    GameObject y;
    // Use this for initialization
    void Start()
    {
        x = GameObject.Find("stairs");
        y = GameObject.Find("stairs2");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            x.GetComponent<elevator>().enabled = false;
        y.GetComponent<elevator2>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            x.GetComponent<elevator>().enabled = true;
            y.GetComponent<elevator2>().enabled = true;
        }
    }
}
