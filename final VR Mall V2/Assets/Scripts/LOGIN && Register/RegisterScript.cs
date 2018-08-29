using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class RegisterScript : MonoBehaviour {

	public GameObject namee;
	public GameObject email;
	
	public GameObject password;

	
	



	private string EmailText,NameText;
	private string PasswordText;

	private string LoginText;


	[SerializeField]
	private Text loadingText;
	
	[Serializable]

	public class userDetail
	{
		// this variable should similar to the json keys in response
		public string name ;
		public int response;
		public string message;
		public string email;
		
		//public string type;
	}



	




	public void GoToLogin(){

		print ("Register  Clicked");



	}

	public void ValidationRegister(){
		NameText = namee.GetComponent<InputField> ().text;
		EmailText = email.GetComponent<InputField> ().text;
		
		PasswordText = password.GetComponent<InputField> ().text;
		


		if (NameText != "" && EmailText != "" &&   PasswordText != "") {
			//print ("Login Successfull");
			//SceneManager.LoadScene (1);
			StartCoroutine(CallRegister(NameText,EmailText,PasswordText));

        } 
           

	}



	


	// Login Request
	public IEnumerator CallRegister(string Namme,string Emaill,string Passwoord){

		// Create a form 
		WWWForm form = new WWWForm();
		form.AddField ("name", Namme);
		form.AddField ("email", Emaill);
		form.AddField ("password", Passwoord);
		
		
		UnityWebRequest www = UnityWebRequest.Post ("//website", form);

		//here we will back our Response.
		yield return www.Send ();

		if (www.error != null) {
			Debug.Log ("ErrorConnection : " + www.error);
			
			loadingText.text ="No Internet" ;
           
		} else {
			Debug.Log ("Response is " + www.downloadHandler.text);
			userDetail userdetail = JsonUtility.FromJson<userDetail> (www.downloadHandler.text);
			if (userdetail.response == 1) {
				Debug.Log ("" + userdetail.message);
				
			} 
            
		}
	
	}  

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator WaitBro(int seconds) {
		// 
		yield return new WaitForSeconds(seconds);

	}


}
