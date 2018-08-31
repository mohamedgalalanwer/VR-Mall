using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
	
	public float SpeedMul = 1f;

	float Speed = 0.001f;
	float RotationSpeed = 4.0f;
	float MinSpeed = 0.8f;
	float MaxSpeed = 2.0f;
	float NeighbourDistance = 3.0f;
	Vector3 AverageHeading;
	Vector3 AveragePosition;
	bool Turning = false;

	[HideInInspector]
	public GlobalFlock MyManager;

	void Start () {
		Speed = Random.Range (MinSpeed, MaxSpeed);
	}

	void Update () {
		/*Bounds B = new Bounds (MyManager.transform.position, MyManager.SwimLimit * 2);

		if (!B.Contains (transform.position))
			Turning = true;
		else
			Turning = false;
		*/
		if (Turning) {
			Vector3 Direction = MyManager.transform.position - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Direction), RotationSpeed * Time.deltaTime);
			Speed = Random.Range (0.5f, 1f) * SpeedMul;
		} 
		else {
			if (Random.Range (0, 10) < 1)
				ApplyRules ();
		}

		transform.Translate (0, 0, Time.deltaTime * Speed);
	}

	void ApplyRules(){
		GameObject[] Gos;
		Gos = GlobalFlock.AllFishes;

		Vector3 VCenter = Vector3.zero;
		Vector3 VAvoid = Vector3.zero;
		Vector3 GoalPos = MyManager.GoalPos;

		float GSpeed = 0.1f;
		float Dist;
		int GroupSize = 0;

		foreach (GameObject Go in Gos) {
			if (Go != this.gameObject) {
				Dist = Vector3.Distance (Go.transform.position, this.transform.position);
				if (Dist <= NeighbourDistance) {
					VCenter += Go.transform.position;
					GroupSize++;

					//increase if the tank size increased	
					if (Dist < 2.0f) {
						VAvoid = VAvoid + (this.transform.position - Go.transform.position);
					}

					Flock AnotherFlock = Go.GetComponent<Flock> ();
					GSpeed = GSpeed + AnotherFlock.Speed;
				}
			}
		}

		if (GroupSize > 0) {
			VCenter = VCenter / GroupSize + (GoalPos - this.transform.position);
			Speed = GSpeed / GroupSize * SpeedMul;

			Vector3 Direction = (VCenter + VAvoid) - transform.position;
			if (Direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Direction), RotationSpeed * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider Other){
		/*if (!Turning) {
			NewGoalPos = this.transform.position - Other.transform.position;
		}*/
		Turning = false;
	}

	void OnTriggerExit(Collider Other){
		Turning = true;
	}
}
