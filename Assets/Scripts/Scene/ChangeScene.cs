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
       // SceneManager.LoadScene("menu");
		Pause = !Pause;
		//Time.timeScale = (Pause) ? 1.00f : 0.00f;
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

			}
			 else {
			 	if (NombreDeScena == "BossFight2") {
				player = GameObject.Find ("Player");
				DontDestroyOnLoad (player);
				mainCamera = GameObject.Find ("Main Camera");
				DontDestroyOnLoad (mainCamera);
				DontDestroyOnLoad(GameObject.Find("Canvas"));
				Pause = !Pause;
				Time.timeScale = (Pause) ? 1.00f : 0.00f;
				SceneManager.LoadScene (NombreDeScena, LoadSceneMode.Single);
				player.transform.position = new Vector2 (0, 0);

			}
				SceneManager.LoadScene (NombreDeScena, LoadSceneMode.Additive);
				if(NombreDeScena=="Generator"){Time.timeScale = (Pause) ? 1.00f : 0.00f;
			}
		}
		}
		Pause = true;
    }
	
	
}
