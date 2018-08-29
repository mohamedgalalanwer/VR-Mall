using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
	public float speed = 0.5f;
	public float ChangeDirectionTime = 2f;
	private float Counter;
	private Animator Ac;

	void Start() {
		Counter = ChangeDirectionTime;
		Ac = GetComponent<Animator> ();
		Ac.SetBool ("sell", true);
	}
	void Update() {
		transform.Translate(new Vector3(0f,0f,2f) * speed * Time.deltaTime);
		int randomint = Random.Range(0, 360);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay(transform.position, fwd * 1.5f, Color.red);

		if (Counter < 0) {
			Counter = ChangeDirectionTime;
			transform.Rotate(0, randomint, 0);
		}
		else if(Physics.Raycast(transform.position, fwd, out hit, 1.5f)) {
			if(hit.collider.tag == "Walls"){
				transform.Rotate(0, randomint, 0);
				Counter = ChangeDirectionTime;
			} 
		}

		Counter -= Time.deltaTime;
	}
}