using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerDeadController : MonoBehaviour {

	GameObject player;
	GameObject atroce;
	Scene activeScene;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		atroce = GameObject.Find ("Atroce");
		activeScene = SceneManager.GetActiveScene ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player==null) {
			reloadScene (activeScene.name);
		}
		if (atroce==null && activeScene.name == "BossFight") {
			reloadScene ("SecondLevel");
		}
	}
	void reloadScene(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
