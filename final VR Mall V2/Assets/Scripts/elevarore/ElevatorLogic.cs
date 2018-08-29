using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogic : MonoBehaviour {
    


    public GameObject isidecub,checkPlayer,elevator,wall,fristpoint,secondpoint;
	void Start () {
       // hinge = GetComponent<HingeJoint>();
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenDoorInside()
    {
        if (elevator.transform.position.y > 0)
        {
            elevator.transform.position = new Vector3(0, 0, 0);
            wall.SetActive(false);
          

            StartCoroutine(openDoorwait());

        }
        else
        {

            elevator.transform.position = new Vector3(0, 0, 0);
            wall.SetActive(false);
            StartCoroutine(openDoorwait());
        }

       

        
    }


    private IEnumerator openDoorwait()
    {
        yield return new WaitForSeconds(1f);
        print("Door open");

        HingeJoint hinge = gameObject.GetComponent<HingeJoint>();
        JointSpring spr = hinge.spring;
        spr.targetPosition = 90;
        hinge.spring = spr;

        isidecub.SetActive(true);
        checkPlayer.SetActive(false);

    }
    public void OpenDoorOutSide()
    {
        print("Door open out ");
        isidecub.SetActive(false);
        checkPlayer.SetActive(true);
        wall.SetActive(false);
        HingeJoint hinge = gameObject.GetComponent<HingeJoint>();
        JointSpring spr = hinge.spring;
        spr.targetPosition = 120;
        hinge.spring = spr;
    }



    public void GoToSecondFloor()
    {

        iTween.MoveTo(elevator,
            iTween.Hash(
                "position", secondpoint.transform.position,
                "time", 5,
                "easetype", "linear"
            )
        );

    }

    public void GoTofristFloor()
    {



    }
}
