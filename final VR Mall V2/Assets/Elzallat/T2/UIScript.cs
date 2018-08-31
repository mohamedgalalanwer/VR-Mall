using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml;

public class UIScript : MonoBehaviour {

	public GameObject UIPrefab;
	public GameObject PanelPosition;
	public GameObject ProductsRoot;

	GameObject Canv;
	GameObject LastProductClicked = null;
	bool OnlyOnce = false;
	string UserID;

	void Start () {
		UserID = PlayerPrefs.GetString ("UserID", "0");
		GetProducts ();
	}

	public void ShowPanel(GameObject Product){
		if (!OnlyOnce) {
			Canv = Instantiate (UIPrefab, PanelPosition.transform.position, this.transform.rotation);
			Canv.transform.GetChild (0).GetChild (4).GetComponent<Button> ().onClick.AddListener (Buy);
			Canv.transform.GetChild (0).GetChild (5).GetComponent<Button> ().onClick.AddListener (ClosePanel);
			OnlyOnce = true;

			LastProductClicked = Product;
			StartCoroutine (GetData (Product));
		}
	}

	void ClosePanel(){
		if (OnlyOnce) {
			Destroy (Canv);
			OnlyOnce = false;
			LastProductClicked = null;
		}
	}

	void Buy(){
		if (OnlyOnce) {
			Canv.transform.GetChild (0).gameObject.SetActive (false);
			Canv.transform.GetChild (1).gameObject.SetActive (true);

			Destroy (Canv,2f);
			OnlyOnce = false;

			//send to database
			SendSelectedProduct();
		}
	}

	void GetProducts(){
		foreach (Transform Child in ProductsRoot.transform) {
			foreach (Transform NestedChild in Child) {
				EventTrigger ET = NestedChild.gameObject.AddComponent<EventTrigger> ();
				EventTrigger.Entry Entry = new EventTrigger.Entry ();
				Entry.eventID = EventTriggerType.PointerClick;
				Entry.callback.AddListener ((eventData) => {
					ShowPanel (NestedChild.gameObject);
				});
				ET.triggers.Add (Entry);
			}
		}
	}


	public IEnumerator GetData(GameObject Product){
		ClassProduct CP = Product.GetComponent<ClassProduct> ();
       
        WWW www = new WWW ("http://mmahgoub-001-site1.htempurl.com/WebService.asmx/GetProductXml?ProductID=" + CP.PID.ToString ());
		yield return www;
		string text = www.text;

		XmlDocument Doc = new XmlDocument ();
		try {
			Doc.LoadXml (text);
			XmlNodeList node = Doc.GetElementsByTagName ("Product");

			CP.Quantity_In_Stock = node [0].ChildNodes.Item (0).InnerText.Trim ();
			CP.Name = node [0].ChildNodes.Item (1).InnerText.Trim ();
			CP.shop = node [0].ChildNodes.Item (2).InnerText.Trim ();
			CP.Description = node [0].ChildNodes.Item (3).InnerText.Trim ();
			CP.Unit_Price = node [0].ChildNodes.Item (4).InnerText.Trim ();
		} catch (XmlException e) {
			print (e.Message);
		}
		Canv.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = CP.Name;
		Canv.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = CP.Description;
		Canv.transform.GetChild (0).GetChild (2).GetComponent<Text> ().text = CP.Unit_Price;
		Canv.transform.GetChild (0).GetChild (3).GetComponent<Image> ().sprite = CP.PSprite;
	}

	void SendSelectedProduct(){
		if (LastProductClicked != null) {
			ClassProduct CP = LastProductClicked.GetComponent<ClassProduct> ();
           
            WWW www = new WWW ("http://mmahgoub-001-site1.htempurl.com/WebService.asmx/SelectedProduct?userID=" + UserID + "&productID=" + CP.PID.ToString());
		}
	}
}
