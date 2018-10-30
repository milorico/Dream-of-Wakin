using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGO : MonoBehaviour {
	public string sceneName;
	bool Pause = false;
	public GameObject arrow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("k"))
		{
			if (arrow.GetComponent<ArrowScript> ().openDoor == true) {
				DontDestroyOnLoad (arrow);
			}
			SceneManager.UnloadSceneAsync("Generator");
			Pause = !Pause;
			Time.timeScale = (Pause) ? 1.00f : 0.00f;


		}
	}
	void OnMouseDown (){
	//	SceneManager.LoadScene (sceneName);
	}
}
