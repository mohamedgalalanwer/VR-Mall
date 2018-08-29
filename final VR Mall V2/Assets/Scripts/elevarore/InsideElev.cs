using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideElev : MonoBehaviour {
    public GameObject door,door2;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Door open out");

            HingeJoint hinge = door.GetComponent<HingeJoint>();
            JointSpring spr = hinge.spring;
            spr.targetPosition = 0;
            hinge.spring = spr;
            HingeJoint hinge2 = door2.GetComponent<HingeJoint>();
            JointSpring spr2 = hinge2.spring;
            spr2.targetPosition = 0;
            hinge2.spring = spr2;
        }

    }
}
