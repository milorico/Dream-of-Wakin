using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonDesarrollador : MonoBehaviour {
	public string nombreScena;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){		
		SceneManager.LoadScene (nombreScena, LoadSceneMode.Single);
	}
}
