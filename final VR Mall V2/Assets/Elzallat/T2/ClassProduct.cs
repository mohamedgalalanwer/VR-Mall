using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassProduct : MonoBehaviour {

    public int PID;
	public Sprite PSprite;

    [HideInInspector]
    public string Name, Description, shop, Unit_Price, Quantity_In_Stock;
}
