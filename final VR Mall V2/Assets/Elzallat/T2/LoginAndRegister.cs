using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using UnityEngine.SceneManagement;

public class LoginAndRegister : MonoBehaviour {

	public GameObject LoginUserName, LoginPassword;
	public GameObject RegisterUserName, RegisterPassword;
	public GameObject LoginUI, RegisterUI;
    public GameObject InvalidLogin, InvalidRegister;

	private string LoginNameText, LoginPassText, RegisterNameText, RegisterPassText;

	void Awake(){
		string UserName = PlayerPrefs.GetString ("UserName", "NA");
        //if (!UserName.Equals("NA"))
        //    SceneManager.LoadScene("Level01");
    }

	public void ValidationLogin(){
		LoginNameText = LoginUserName.GetComponent<InputField> ().text;
		LoginPassText = LoginPassword.GetComponent<InputField> ().text;

		if (LoginNameText != "" && LoginPassText != "") {
            StartCoroutine(CallLogin(LoginNameText, LoginPassText));
		}
        else
        {
            LoginUserName.GetComponent<InputField>().text = "";
            LoginPassword.GetComponent<InputField>().text = "";
            StartCoroutine(InvalidInput(InvalidLogin));
        }
	}

	public void ValidationRegister(){
		RegisterNameText = RegisterUserName.GetComponent<InputField> ().text;
		RegisterPassText = RegisterPassword.GetComponent<InputField> ().text;

		if (RegisterNameText != "" &&   RegisterPassText != "") {
			StartCoroutine(CallRegister(RegisterNameText, RegisterPassText));
        }
        else
        {
            RegisterUserName.GetComponent<InputField>().text = "";
            RegisterPassword.GetComponent<InputField>().text = "";
            StartCoroutine(InvalidInput(InvalidRegister));
        }
	}

	public void OpenRegister(){
		LoginUI.SetActive (false);
		RegisterUI.SetActive (true);
	}

	public void OpenLogin(){
		LoginUI.SetActive (true);
		RegisterUI.SetActive (false);
	}

	public IEnumerator CallLogin(string User,string Pass){
		WWW www = new WWW ("http://mmahgoub-001-site1.htempurl.com/WebService.asmx/LogInXml?Username=" + User + "&Password=" + Pass);
		yield return www;
		string text = www.text;

		XmlDocument Doc = new XmlDocument ();
		try {
			Doc.LoadXml (text);
			XmlNodeList node = Doc.GetElementsByTagName ("Customer");

			string userid = node [0].ChildNodes.Item (0).InnerText.Trim ();
			print("id is " + userid);
			if(int.Parse(userid)!=0){
				PlayerPrefs.SetString("UserID", userid);
				PlayerPrefs.SetString("UserName", User);
				PlayerPrefs.SetString("UserPassword", Pass);
				SceneManager.LoadScene("Level01");
			}
            else
            {
                LoginUserName.GetComponent<InputField>().text = "";
                LoginPassword.GetComponent<InputField>().text = "";
                StartCoroutine(InvalidInput(InvalidLogin));
            }
		} catch (XmlException e) {
			print (e.Message);
		}
	}

	public IEnumerator CallRegister(string User, string Pass){
		WWW www = new WWW ("http://melsayed-001-site1.gtempurl.com/WebService.asmx/RegisterXml?Username=" + User + "&Password=" + Pass);
		yield return www; 
        string text = www.text;

		XmlDocument Doc = new XmlDocument ();
		try {
			Doc.LoadXml (text);
			XmlNodeList node = Doc.GetElementsByTagName ("Customer");

			string userid = node [0].ChildNodes.Item (0).InnerText.Trim ();
			print("id is " + userid);
			if(int.Parse(userid)!=0){
				PlayerPrefs.SetString("UserID", userid);
				PlayerPrefs.SetString("UserName", User);
				PlayerPrefs.SetString("UserPassword", Pass);
				SceneManager.LoadScene("Level01");
			}
            else
            {
                RegisterUserName.GetComponent<InputField>().text = "";
                RegisterPassword.GetComponent<InputField>().text = "";
                StartCoroutine(InvalidInput(InvalidRegister));
            }
		} catch (XmlException e) {
			print (e.Message);
		}
	}

    IEnumerator InvalidInput(GameObject Text)
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(2f);
        Text.SetActive(false);
    }
}
