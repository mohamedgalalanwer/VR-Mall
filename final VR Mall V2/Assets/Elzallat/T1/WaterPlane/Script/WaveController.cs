using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public float Height;
	public float Time;

	// Use this for initialization
	void Start () {
		iTween.MoveBy (this.gameObject, iTween.Hash ("y", Height, "time", Time, "looptype", "pingpong","easetype",iTween.EaseType.easeInOutSine));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
