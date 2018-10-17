using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemsProgress : MonoBehaviour {

	public ItemPickedUp sopleteichon;
	public ItemPickedUp secondRoomKey;
	public ItemPickedUp generatorKey;

	public GameObject secondRoomDoor;
	public GameObject generatorCol;
	public GameObject iceStatue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sopleteichon.CheckItemIsPicked() == true) {
			iceStatue.GetComponent<CloseEnoughtToInteract> ().destroyable = true;
			if (iceStatue==null) {
				secondRoomKey.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}
}
