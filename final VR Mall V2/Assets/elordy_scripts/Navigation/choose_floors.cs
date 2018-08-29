using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choose_floors : MonoBehaviour
{
    List<string> first_shops;
    List<string> second_shops;
    public GvrDropdown Drop_List;
    public GameObject[] waypoints;
    GameObject Player;
    // Use this for initialization
    void Start()
    {////اضف المكعبات عند المحلات  2-وسميهم باسمائهم3-اديلهم تاج تارجت 4-سمى الااعب اللاول باسم التاج لاعب  
        waypoints = GameObject.FindGameObjectsWithTag("targets");//this is tag of cubes
        Player = GameObject.FindGameObjectWithTag("Player");  ///

        first_shops = new List<string>();
        second_shops = new List<string>();

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i].transform.position.y>8f)
            {
                second_shops.Add(waypoints[i].name);
                print(waypoints[i].name);
                Drop_List.ClearOptions();
                Drop_List.AddOptions(second_shops);
            }
            else
            {
                first_shops.Add(waypoints[i].name);
                print(waypoints[i].name);

                Drop_List.ClearOptions();
                Drop_List.AddOptions(first_shops);
            }
        }
        //first_shops.Add("shoes");
        //first_shops.Add("cars");
        //first_shops.Add("closthes");
        //second_shops.Add("coffee");
        //second_shops.Add("supermarket");
        //second_shops.Add("gold");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clicked()
    {
        if (this.name == "First_Floor")
        {
           
            Drop_List.ClearOptions();
            Drop_List.AddOptions(first_shops);

        }
        else if (this.name == "Second_Floor")
        {
            Drop_List.ClearOptions();
            Drop_List.AddOptions(second_shops);
        }
        

    }
    public void choose_shop(int value)
    {
        Text Text = Drop_List.GetComponentInChildren<Text>();
        string Selected_Text = Text.text;
        GoToShop(Selected_Text);
    }

    private void GoToShop(string ShopName)
    {
        Player.transform.position = GameObject.Find(ShopName).transform.position;
    }
}
