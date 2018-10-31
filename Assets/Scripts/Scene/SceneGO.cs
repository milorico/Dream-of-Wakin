using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGO : MonoBehaviour {
	public Scene sceneName;
	bool Pause = false;
	public GameObject arrow;
	public Hits puntos;
	// Use this for initialization
	void Start () {
		sceneName = SceneManager.GetSceneAt (1);
		if(puntos != null){
		puntos = GameObject.Find("Main Camera 2").GetComponent<Hits>();}
		print(sceneName.name);
	}
	// Update is called once per frame
	void Update () {
		if(puntos!=null){
if(puntos.points==16){
	SceneManager.UnloadSceneAsync(sceneName);
	DontDestroyOnLoad(puntos);
	puntos.GetComponent<Camera>().enabled =false;
}}
		if (Input.GetKeyDown("k"))
		{
			if(arrow !=null){
			if (arrow.GetComponent<ArrowScript> ().openDoor == true)  {
				DontDestroyOnLoad (arrow);
			}
		}
		
			SceneManager.UnloadSceneAsync(sceneName);
			Pause = !Pause;
			Time.timeScale = (Pause) ? 1.00f : 0.00f;
		}
	}
	void OnMouseDown (){
	//	SceneManager.LoadScene (sceneName);
	}
}
