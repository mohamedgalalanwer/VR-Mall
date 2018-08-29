using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    GameObject x;
    GameObject y;
    Transform first_step;
    Transform temp1;
    Transform destination;
    public float speed;
    float step;
    ///
    GameObject Player;

    // Use this for initialization
    void Start()
    {
        x = GameObject.Find("Box759.001");
        y = GameObject.Find("Box754.001");
        Player = GameObject.FindGameObjectWithTag("Player");

        first_step = y.transform;
        destination = x.transform;
        step = speed * Time.deltaTime;



    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform child in transform)
        {
            if (child.position == destination.position)
            {

                child.position = first_step.position;
            }
            else
            {
                temp1 = child;
                child.position = Vector3.MoveTowards(child.position, destination.position, step);
            }
        }

    }



   
}
