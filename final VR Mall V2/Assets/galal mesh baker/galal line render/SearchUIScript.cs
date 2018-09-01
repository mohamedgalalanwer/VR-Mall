using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;
public class SearchUIScript : MonoBehaviour {

	public GameObject ProductsRoot;
	public GameObject BtnProductsParent;
	public GameObject BtnShopsParent;
	public GameObject BtnProductPrefab;
	public GameObject BtnShopPrefab;
    public Button bttn;
    public GameObject panelShopCanvas;

    public GameObject Player ,enterStair1,enterStair2,exitStair1,exitStair2;


	Dictionary<string,List<string>> ProductsAndShops = new Dictionary<string, List<string>> ();
	List<KeyValuePair<string,List<string>>> FoundProducts = new List<KeyValuePair<string, List<string>>> ();

	List<string> Tmp;
	void Start () {
		foreach (Transform Child in ProductsRoot.transform) {
			foreach (Transform Product in Child) {
				if (!ProductsAndShops.ContainsKey (Product.gameObject.name)) {
					Tmp = new List<string> ();
					Tmp.Add (Product.parent.gameObject.name);
					ProductsAndShops.Add (Product.gameObject.name, Tmp);
				} else {
					Tmp = ProductsAndShops [Product.gameObject.name];
					Tmp.Add (Product.parent.gameObject.name);
					ProductsAndShops [Product.gameObject.name] = Tmp;
				}
			}
		}
	}

	public void HideShowPanel(GameObject SearchPanel){
		if (SearchPanel.activeInHierarchy)
			SearchPanel.SetActive (false);
		else
			SearchPanel.SetActive (true);
	}

	string Input;
	public void OnInputFieldValueChange(Text InputFieldText){
		//clear old products in the search
		FoundProducts.Clear ();
		foreach (Transform Child in BtnProductsParent.transform)
			Destroy (Child.gameObject);

		//find similar products
		Input = InputFieldText.text.Trim().ToLower();
		if (Input != null && Input.Length > 1) {
			foreach(KeyValuePair<string,List<string>> item in ProductsAndShops){
				if (item.Key.ToLower ().Contains (Input)) {
					FoundProducts.Add (item);
				}
			}
		}

		//add similar products puttons
		foreach (KeyValuePair<string,List<string>> Product in FoundProducts) {
			GameObject Btn = Instantiate (BtnProductPrefab, BtnProductsParent.transform);
			Btn.GetComponentInChildren<Text> ().text = Product.Key;
            ///add photo 
            


			//onclick show shops
			Btn.GetComponent<Button> ().onClick.AddListener (delegate {
				OnProductButtonClicked(Product);
			}); 
		}
	}

	void OnProductButtonClicked(KeyValuePair<string,List<string>> item){
		//clear old Shops in the search
		foreach (Transform Child in BtnShopsParent.transform)
			Destroy (Child.gameObject);

		foreach (string Shop in item.Value) {
			GameObject ShopBtn = Instantiate (BtnShopPrefab, BtnShopsParent.transform);
			ShopBtn.GetComponentInChildren<Text> ().text = Shop;
            ///add  photo
            ///
			//onclick Go To Shop
			ShopBtn.GetComponent<Button> ().onClick.AddListener (delegate {
				GoToShop(Shop);
			}); 
		}
	}

	void GoToShop(string ShopName) {
		switch (ShopName) {
            case "Tradeline":
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);

                NavAgentExample.CurrentIndex = 1;
			//go to shop1
			//player.transform.position = point1.transform.position
			print("Go TO Shop1");
			break;
            case "Samsonite":
			//go to shop1
            panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 4;
			//player.transform.position = point1.transform.position
			print("Go TO Shop2");
			break;
            case "Ravin":
			//go to shop1
            panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 5;
			//player.transform.position = point1.transform.position
			print("Go TO Shop3");
			break;
            case "FILTER":
                //go to shop1
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 6;
                //player.transform.position = point1.transform.position
                print("Go TO Shop3");
                break;
            case "CARREFOUR":
                //go to shop1
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 2;
                //player.transform.position = point1.transform.position
                print("Go TO Shop3");
                break;

            case "SUNGLASS HUT":
                //go to shop1
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 7;
                //player.transform.position = point1.transform.position
                print("Go TO Shop3");
                break;
            case "ZARA":
                //go to shop1
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 8;
                //player.transform.position = point1.transform.position
                print("Go TO Shop3");
                break;
            case "Cinema":
                //go to shop1
                bttn.GetComponent<Button>().interactable = true;
                panelShopCanvas.SetActive(false);
                Player.GetComponent<AutoWalk>().enabled = false;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<NavAgentExample>().enabled = true;
                enterStair1.SetActive(false);
                enterStair2.SetActive(false);
                exitStair1.SetActive(false);
                exitStair2.SetActive(false);
                NavAgentExample.CurrentIndex = 3;
                //player.transform.position = point1.transform.position
                print("Go TO Shop3");
                break;


            default:
			break;
		}
	}
}
