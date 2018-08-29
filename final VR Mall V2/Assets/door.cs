using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    //public float distance;
    //public Transform d1;
    //public Transform d2;
    //public float speed_door;
    //public Transform new_d1;
    //Transform new_d2;
    //public GameObject cube;
    Transform d1;
    Transform d2;
    Transform fixedd1;
    Transform fixedd2;
    Vector3 temp1;
    Vector3 temp2;
    public float speed;
    // Use this for initialization
    void Start()
    {
         d1 = transform.Find("Rectangle04");
         d2 = transform.Find("Rectangle08");
         fixedd1 = transform.Find("Rectangle01");
         fixedd2 = transform.Find("Rectangle07");
         temp1 = d1.position;
         temp2 = d2.position;

        //Vector3 v = new Vector3(.740f, 0, 0);
        //new_d1.position = new Vector3(d1.position.x + .740f, d1.position.y, d1.position.z);
        // new_d2.position = new Vector3(d2.position.x + .740f, d1.position.y, d1.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //d1.position = Vector3.MoveTowards(d1.position, temp1, step);
        //d2.position = Vector3.MoveTowards(d2.position, temp2, step);
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, Vector3.forward);
        //Debug.DrawRay(transform.position, Vector3.forward*20 , Color.red);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    //float step = speed_door * Time.deltaTime;
        //    print(hit.collider.name);
        //    //d1.position = Vector3.MoveTowards(d1.position, new_d1.position, step);
        //   // m_Material = GetComponent<Renderer>().material;
        //}
        
    }
   
    void OnTriggerEnter(Collider other)
    {
        //////float step = speed * Time.deltaTime;
        //////d1.position = Vector3.MoveTowards(d1.position, fixedd1.position, step);
        //////d2.position = Vector3.MoveTowards(d2.position, fixedd2.position, step);
    // d1.position = fixedd1.position;
     // d2.position = fixedd2.position;
        float step = speed * Time.deltaTime;
        d1.position = Vector3.MoveTowards(d1.position, fixedd1.position, step);
        d2.position = Vector3.MoveTowards(d2.position, fixedd2.position, step);
       
    }
    void OnTriggerExit(Collider other)
    {
        //float step = speed * Time.deltaTime;
        //d1.position = Vector3.MoveTowards(d1.position, temp1, step);
        //d2.position = Vector3.MoveTowards(d2.position, temp1, step);
        d1.position =temp1;
        d2.position = temp2;
    }
    void OnTriggerStay(Collider other)
    {
        //d1.position = fixedd1.position;
        //d2.position = fixedd2.position;
        float step = speed * Time.deltaTime;
        d1.position = Vector3.MoveTowards(d1.position, fixedd1.position, step);
        d2.position = Vector3.MoveTowards(d2.position, fixedd2.position, step);
    
    
    }
}
