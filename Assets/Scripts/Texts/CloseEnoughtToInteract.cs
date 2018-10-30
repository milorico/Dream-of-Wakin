using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnoughtToInteract : MonoBehaviour {
	public bool destroyable = false;
	public GameObject target;  
	public bool interactuable = false;
	// The game object to affect. If none, the trigger work on this game object
	public GameObject TextThatAppearsWhenInteracted;
	public GameObject fog;
	public AudioSource itemSound;
//	public GameObject TextThatAppearsWhenInteracted2;
	public int turnoDelDialogo = 0;
	// Use this for initialization
	void Start () {
		if ( TextThatAppearsWhenInteracted!=false) {
			TextThatAppearsWhenInteracted.SetActive (false);
		}

		//TextThatAppearsWhenInteracted2.SetActive (false);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (interactuable==true) {
			EnableText ();
		}

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == target.name) {
			interactuable = true;
		}
	

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
			if (TextThatAppearsWhenInteracted!=null) {
				TextThatAppearsWhenInteracted.SetActive (false);
			}
			interactuable = false;
		}
	}
	private void EnableText (){
		if (Input.GetKeyDown("k"))
			{
			if (this.gameObject.GetComponent<ChangeScene>()!=null) {
				
				if (GameObject.Find("arrow")==null) {
					turnoDelDialogo = 1;
				if (turnoDelDialogo==1) {
					this.gameObject.GetComponent<ChangeScene> ().CambioDeScena ("Generator");
					//turnoDelDialogo = 1;
					}
				}
				else  {
					turnoDelDialogo = 2;
					if (this.gameObject.name == "DetecterBoss") {
						this.gameObject.GetComponent<ChangeScene> ().CambioDeScena ("BossZone1");
					}
				}
			}
			if (turnoDelDialogo==0&&TextThatAppearsWhenInteracted!=null ) {
				TextThatAppearsWhenInteracted.SetActive (true);
			}
				if (destroyable ==true) {
				StartCoroutine (WaitForTransition (1.4f));
				TextThatAppearsWhenInteracted.SetActive (false);
					Destroy (this.gameObject,1);

				}
				} 

			}

	private IEnumerator WaitForTransition(float waitTime)
	{

		fog.SetActive(true);
		itemSound.Play (0);
		yield return new WaitForSeconds(waitTime);
		fog.SetActive(false);

	}

}
