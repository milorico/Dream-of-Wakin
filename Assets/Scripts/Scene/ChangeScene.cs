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
<<<<<<< HEAD
<<<<<<< HEAD

<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD


=======
<<<<<<< HEAD

<<<<<<< HEAD
>>>>>>> parent of 5be8477... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
>>>>>>> be8fdbd3b2116a079338556e07a9977c402f27ee
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> parent of f4a8e59... Lvl 3
=======
<<<<<<< HEAD
>>>>>>> parent of 064a6e7... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
=======
>>>>>>> parent of 2c1a48a... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
        SceneManager.LoadScene("menu");

=======
>>>>>>> parent of 26270fc... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
>>>>>>> parent of 92b663a... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
        SceneManager.LoadScene("menu");

=======
>>>>>>> parent of 5be8477... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
>>>>>>> parent of 77601e1... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
=======
        SceneManager.LoadScene("menu");


>>>>>>> parent of babf40a... Revert "Lvl 3"
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 5be8477... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"

=======
>>>>>>> be8fdbd3b2116a079338556e07a9977c402f27ee
=======
>>>>>>> 24fe0cd13b927899b443f425214ef765b606f366
>>>>>>> parent of f4a8e59... Lvl 3
<<<<<<< HEAD
>>>>>>> parent of 26270fc... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
>>>>>>> parent of 064a6e7... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
=======
>>>>>>> parent of 2c1a48a... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
=======
=======

>>>>>>> parent of 92b663a... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
>>>>>>> parent of 5be8477... Revert "Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin"
=======
>>>>>>> parent of 77601e1... Merge branch 'master' of https://github.com/milorico/Dream-of-Wakin
=======

=======
>>>>>>> be8fdbd3b2116a079338556e07a9977c402f27ee
>>>>>>> parent of babf40a... Revert "Lvl 3"

			} else {
				SceneManager.LoadScene (NombreDeScena, LoadSceneMode.Additive);
			}
		}
		Pause = true;
    }
	
	
}
