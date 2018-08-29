using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablechoose_floor : MonoBehaviour
{

    GameObject navigationTOShop;
    GameObject Mycamera;
    bool visible = false;

    // Use this for initialization
    void Start()
    {
        navigationTOShop = GameObject.Find("navigationTOShop");
        Mycamera = GameObject.FindGameObjectWithTag("MainCamera"); 
    }

    // Update is called once per frame
    void Update()
    {

    }

  public  void Toggle_navigationTOShop()
    {
        if (visible == false)
        {
            navigationTOShop.SetActive(true);
            navigationTOShop.transform.position = Mycamera.transform.position+ new  Vector3(-2f,0,0);
            visible = true;
        }
        else if (visible == true)
        {
            navigationTOShop.SetActive(false);
            visible = false;
        }
      
    }
}
