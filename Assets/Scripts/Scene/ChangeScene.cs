using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ChangeScene : MonoBehaviour {
	bool Pause = true;
	// Use this for initialization
	GameObject player;
	GameObject mainCamera;
	public void CambioDeScena  (string NombreDeScena) {
<<<<<<< HEAD

=======
<<<<<<< HEAD

<<<<<<< HEAD

=======
>>>>>>> be8fdbd3b2116a079338556e07a9977c402f27ee
=======
<<<<<<< HEAD
>>>>>>> parent of f4a8e59... Lvl 3
        SceneManager.LoadScene("menu");

=======
>>>>>>> parent of 26270fc... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
		Pause = !Pause;
		Time.timeScale = (Pause) ? 1.00f : 0.00f;
		if (Pause == false)
		{
			if (NombreDeScena == "BossZone1") {
				player = GameObject.Find ("Player");
				DontDestroyOnLoad (player);
				mainCamera = GameObject.Find ("Main Camera");
				DontDestroyOnLoad (mainCamera);
				DontDestroyOnLoad(GameObject.Find("Canvas"));
				Pause = !Pause;
				Time.timeScale = (Pause) ? 1.00f : 0.00f;
				SceneManager.LoadScene (NombreDeScena, LoadSceneMode.Single);
				player.transform.position = new Vector2 (0, 0);
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> be8fdbd3b2116a079338556e07a9977c402f27ee
=======
>>>>>>> 24fe0cd13b927899b443f425214ef765b606f366
>>>>>>> parent of f4a8e59... Lvl 3
>>>>>>> parent of 26270fc... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"

			} else {
				SceneManager.LoadScene (NombreDeScena, LoadSceneMode.Additive);
			}
		}
		Pause = true;
    }
	
	
}
