using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor_ascensire : MonoBehaviour {
    GameObject d1;
    GameObject d2;
	// Use this for initialization
	void Start () {
        d1 = GameObject.Find("Box002");
        d2 = GameObject.Find("Box003");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        d1.transform.Translate(-.001f, 0, 0, Space.Self);
        d2.transform.Translate(-.002f, 0, 0, Space.Self);
    }



}
