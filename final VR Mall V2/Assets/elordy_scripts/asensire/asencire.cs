using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asencire : MonoBehaviour {
    Rigidbody rb;
    public float thrust;
    public  GameObject x;
    public float speed;
    float step;
    public Transform[] floors;
    GameObject d1;
    GameObject d2;

	// Use this for initialization
	void Start () {
       // rb = GetComponent<Rigidbody>();
        step = speed * Time.deltaTime;
      //  transform.position = Vector3.MoveTowards(transform.position, x.transform.position, step);
        transform.position = Vector3.Lerp(transform.position, x.transform.position, step);
        floors = new Transform[2];
        d1 = GameObject.Find("Box002");
        d2 = GameObject.Find("Box003");

	}
	

	// Update is called once per frame
	void Update () {

        //transform.position = Vector3.MoveTowards(transform.position, x.transform.position, step);
      //  transform.position = Vector3.Lerp(transform.position, x.transform.position, step);

        d1.transform.Translate(-.001f, 0, 0, Space.Self);
        d2.transform.Translate(-.001f, 0, 0, Space.Self);
	}
    void OnTriggerEnter(Collider other)
    { 
      //  transform.Translate(Vector3.up);
         //rb = GetComponent<Rigidbody>();
         //rb.AddForce(transform.up * thrust);
        
    }
    void OnTriggerExit(Collider other)
    {
        
    }
    void OnTriggerStay(Collider other)
    {
       


    }
}
