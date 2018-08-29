using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour {


	public GameObject email;
	public GameObject password;
	public GameObject login;
	public GameObject register;


    


	private string EmailText;
	private string PasswordText;

	//private string LoginText;


	[SerializeField]
	private Text loadingText;
	//private bool loadScene = false;


	// Model Class For Capture Response 
	[Serializable]

	public class userDetail
	{
		// this variable should similar to the json keys in response
        public string email;
		public int response;
	
	}


    
	

	public void validationLogin(){
		EmailText = email.GetComponent<InputField> ().text;
		PasswordText = password.GetComponent<InputField> ().text;

       



		if (EmailText != "" && PasswordText != "") {
			//print ("Login Successfull");
			//SceneManager.LoadScene (1);
			StartCoroutine(CallLogin(EmailText,PasswordText));

		} 
       
			
	}

	public void RegiterFunction(){

		print ("Register  Clicked");

        

	}

	// Login Request
	public IEnumerator CallLogin(string Emaill,string Paswoord){
		
		// Create a form 
		WWWForm form = new WWWForm();
		form.AddField ("useremail", Emaill);
		form.AddField ("userpassword", Paswoord);

        ///
        ////
		UnityWebRequest www = UnityWebRequest.Post ("//////website", form);

		//here we will back our Response.
		yield return www.Send ();

		if (www.error != null) {
			Debug.Log ("ErrorConnection : " + www.error);
            
			loadingText.text = "";
		} else {
			Debug.Log ("Response is " + www.downloadHandler.text);
			userDetail userdetail = JsonUtility.FromJson<userDetail> (www.downloadHandler.text);
			if (userdetail.response == 1) {
				Debug.Log ("Login Success : Name is : " + userdetail.email);
			
				//StartCoroutine(LoadNewScene(1));
			} 
            else {
				Debug.Log ("Login Failed : Check Paramters");
               
				loadingText.text = "";
			
			}
		}
	}  





	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator WaitBro(int seconds) {
		// 
		yield return new WaitForSeconds(seconds);

	}



}
