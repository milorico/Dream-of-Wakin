using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyItemsProgress : MonoBehaviour {

	public ItemPickedUp sopleteichon;
	public ItemPickedUp secondRoomKey;
	public ItemPickedUp generatorKey;
	ArrowScript arrow;
	public GameObject secondRoomDoor;
	public GameObject generatorCol;
	public GameObject iceStatue;
	public GameObject BigDoor;
	public GameObject BossEnabler;
	Scene m_Scene;
	bool levelOneFinished;
	public GameObject [] puzzlePieces = new GameObject[8];
	public GameObject puzzleDoor;
	bool levelTwoFinished;
	int piecesPicked;
	// Use this for initialization
	void Start () {
		m_Scene = SceneManager.GetActiveScene ();
		print (m_Scene.name);

		if (m_Scene.name =="SecondLevel") {
			piecesPicked = 0;
			levelOneFinished = true;
			levelTwoFinished = false;
		}
	}
	
	// Update is called once per frames
	void Update () {

		if (levelOneFinished==false) {
				if (iceStatue != null && sopleteichon.CheckItemIsPicked () == true) {
					iceStatue.GetComponent<CloseEnoughtToInteract> ().destroyable = true;
				}
			if (iceStatue == null) {
				print ("se derritio");
				if (!secondRoomKey.CheckItemIsPicked () && secondRoomKey != null) {
					secondRoomKey.GetComponent<SpriteRenderer> ().enabled = true;
					secondRoomKey.GetComponent<CircleCollider2D> ().enabled = true;
				}
			}
			if (secondRoomKey.CheckItemIsPicked () && secondRoomKey != null) {
				secondRoomDoor.GetComponent<DoorsInteractive> ().enabled = true;
			}
			if (generatorKey.CheckItemIsPicked () && generatorKey != null) {
				generatorCol.GetComponent<DoorsInteractive> ().enabled = true;
			}
			if (GameObject.Find ("arrow") != null) {
				if (GameObject.Find ("arrow").GetComponent<ArrowScript> ().openDoor == true) {
					BigDoor.SetActive (false);
					BossEnabler.GetComponent<CloseEnoughtToInteract> ().enabled = true;
					levelOneFinished = true;
				}
			}
		}
		if (levelTwoFinished==false && levelOneFinished==true) {
			CountPieces (0);
			print (piecesPicked);
		}
	}
	void CountPieces(int qnt){
		foreach (GameObject item in puzzlePieces) {
			if (item.GetComponent<ItemPickedUp> ().CheckItemIsPicked() == true) {
				qnt++;
			}
		}
		piecesPicked = qnt;
	}
}
