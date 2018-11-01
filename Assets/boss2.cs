using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

private void OnTriggerStay2D(Collider2D other)
    {
     //   EnableText(other);
    	if (Input.GetKeyDown ("k")) {
				this.gameObject.GetComponent<ChangeScene> ().CambioDeScena ("BossFight2");
			}
    }
	
}
