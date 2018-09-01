using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ss : MonoBehaviour {
    public Button b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void enter()
    {

        b.enabled = true;

    }
    public void exitt()
    {

        b.enabled = false;

    }
}
