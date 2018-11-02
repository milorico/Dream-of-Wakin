using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenplayController : MonoBehaviour {

	//SP is a screenplay
	//AS is a sound
	public GameObject NoteText;
	public GameObject DeadText;
	public GameObject Gun;
	bool noteRead;
	bool gunActive;

	

	// Use this for initialization
	void Start () {
		NoteText.SetActive(false);
		noteRead = false;
		gunActive = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (noteRead){
			NoteText.SetActive(true);
		}
	}

	void OnCollisionExit2D ( Collision2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            noteRead = true;
        }
    }

     void OnCollisionStay2D (Collision2D other)
    {
    	if ((other.gameObject.CompareTag("Deceased"))&(Input.GetKeyDown(KeyCode.K)))
        {
            print("Tenemos arma pez");
            gunActive = true;
            Destroy(DeadText);
            Destroy(Gun);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TextOnce"))
        {
            Destroy (other);
        }
    }
}
