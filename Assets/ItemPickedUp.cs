using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickedUp : MonoBehaviour {
	bool playerHasItem;
	// Use this for initialization
	void Start () {
		playerHasItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player") == true) {
			
			if (Input.GetKeyDown ("k")) {
				PlayerPickedItem ();
			}
		}
			
	}
	public void PlayerPickedItem (){
		playerHasItem = true;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;	
	}
	public bool CheckItemIsPicked(){
		return playerHasItem;
	}
}
