using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rgister_LOGIN : MonoBehaviour {

    public GameObject login;
    public GameObject reg;
    public void ChooseRegister() {

        login.SetActive(false);
        reg.SetActive(true);
    
    
    }
}
