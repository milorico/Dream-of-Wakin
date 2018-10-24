using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryStatus : MonoBehaviour {
	//public GameObject healthPack;
	public GameObject[] healthPacks = new GameObject[10];
	ItemPickedUp []playerHasItem = new ItemPickedUp[10];
	Text qntHealthPacks;
	int healthPacksInt;
	int amount=0;
	// Use this for initialization
	void Start () {
		//healthPack = GameObject.Find ("HealthPackButton");
		qntHealthPacks = GameObject.Find ("/Canvas/HealthPackButton/TextHealth").GetComponent<Text> ();
		healthPacks = GameObject.FindGameObjectsWithTag ("HealthPack");
		healthPacksInt = healthPacks.Length;
		//ESTO CUENTA Y ASIGNA LOS SCRIPTS DE LAS CURAS AL CONTADOR EN EL INVENTARIO SOLO SI EL JUGADOR YA LAS RECOGIO
		Sort();
		//qntHealthPacks.text = amount.ToString();
	}
	// Update is called once per frame
	void Update () {
		

	}
	void Sort(){
		for (int i = 0; i < healthPacksInt; i++) {
			playerHasItem [i] = healthPacks [i].GetComponent<ItemPickedUp>();
			if (playerHasItem[i].playerHasItem==true) {
				amount++;
			}
		}
		qntHealthPacks.text = amount.ToString();
	}
	public void Heal(){
		print ("curado papu");
		playerHasItem [amount].playerHasItem = false;
		Sort ();
	}
}

