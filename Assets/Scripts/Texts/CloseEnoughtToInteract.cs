using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnoughtToInteract : MonoBehaviour {
	public bool destroyable = false;
	public GameObject target;  
	public bool interactuable = false;
	// The game object to affect. If none, the trigger work on this game object
	public GameObject TextThatAppearsWhenInteracted;
//	public GameObject TextThatAppearsWhenInteracted2;
	int turnoDelDialogo = 0;
	// Use this for initialization
	void Start () {
		TextThatAppearsWhenInteracted.SetActive (false);
		//TextThatAppearsWhenInteracted2.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (interactuable==true) {
			EnableText ();
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		interactuable = true;
		//EnableText (other);
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		
		//print ("reeeeeeeeee");
		//EnableText (other);


	}
	private void OnTriggerExit2D(Collider2D other)
	{
		print ("sali");
		if (other.name == target.name) {
			TextThatAppearsWhenInteracted.SetActive (false);
			interactuable = false;
		}
	}
	private void EnableText (){
			if (Input.GetKeyDown("k"))
			{
				TextThatAppearsWhenInteracted.SetActive (true);
				if (destroyable ==true) {
					Destroy (this.gameObject,1);
				}
				} 
			}
}
