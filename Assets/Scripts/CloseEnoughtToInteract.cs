using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnoughtToInteract : MonoBehaviour {

	public GameObject target;   
	// The game object to affect. If none, the trigger work on this game object
	public GameObject TextThatAppearsWhenInteracted;
	public GameObject TextThatAppearsWhenInteracted2;
	int turnoDelDialogo = 0;
	// Use this for initialization
	void Start () {
		TextThatAppearsWhenInteracted.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{

		EnableText (other);
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		EnableText (other);

	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == target.name) {
			TextThatAppearsWhenInteracted.SetActive (false);
			if (TextThatAppearsWhenInteracted2 != null) {
				TextThatAppearsWhenInteracted2.SetActive (false);
			}
		}
	}
	private void EnableText ( Collider2D other){
		if (other.name == target.name) {

			if (Input.GetKeyDown("k"))
			{
	         	
				if (TextThatAppearsWhenInteracted2 != null && turnoDelDialogo ==1) {
					TextThatAppearsWhenInteracted2.SetActive (true);
				} else {
					TextThatAppearsWhenInteracted.SetActive(true);
					turnoDelDialogo = 1;
				}
			}
		}
	}
}
