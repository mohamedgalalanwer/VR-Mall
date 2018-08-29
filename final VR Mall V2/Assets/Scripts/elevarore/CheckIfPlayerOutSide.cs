using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerOutSide : MonoBehaviour {
    public GameObject isidecub, door,door2,wall1,wall2;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Door open out ");
            isidecub.SetActive(true);
            HingeJoint hinge = door.GetComponent<HingeJoint>();
            JointSpring spr = hinge.spring;
            spr.targetPosition = 0;
            hinge.spring = spr;

            HingeJoint hinge2 = door2.GetComponent<HingeJoint>();
            JointSpring spr2 = hinge2.spring;
            spr2.targetPosition = 0;
            hinge2.spring = spr2;

            gameObject.SetActive(false);
            wall1.SetActive(true);
            wall2.SetActive(true);
        }

    }
}
