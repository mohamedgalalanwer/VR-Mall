using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 10f;
	public float turnSpeed = 50f;


	void Update()
	{
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 2.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}
}
