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
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
		levelOneFinished = false;
=======
		m_Scene = SceneManager.GetActiveScene ();
		print (m_Scene.name);

		if (m_Scene.name =="SecondLevel") {
			piecesPicked = 0;
			levelOneFinished = true;
			levelTwoFinished = false;
		}
>>>>>>> parent of 26270fc... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
		m_Scene = SceneManager.GetActiveScene ();
		print (m_Scene.name);

		if (m_Scene.name =="SecondLevel") {
			piecesPicked = 0;
			levelOneFinished = true;
			levelTwoFinished = false;
		}
=======
		levelOneFinished = false;
>>>>>>> parent of 92b663a... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
>>>>>>> parent of 5be8477... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
		levelOneFinished = false;
>>>>>>> parent of 77601e1... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
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
	}
}
