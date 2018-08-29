using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_Mange : MonoBehaviour {
    public GameObject email,password,login;
    public Button btnLogin;
    private string emailTxt,passwordTxt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        emailTxt = email.GetComponent<InputField> ().text;
        passwordTxt = password.GetComponent<InputField> ().text;

        btnLogin = login.GetComponent<Button> ();
        btnLogin.onClick.AddListener (ValidDataLogin);
	}
    private void ValidDataLogin(){

        if (emailTxt != "" && passwordTxt != "") {
        
            print ("success");
        
        } else {
        
        
        }



    }
}
