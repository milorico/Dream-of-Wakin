using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsInteractive : MonoBehaviour {
    public Transform pos;
    public GameObject target;
    bool Pause = true;
    public GameObject fog;
    int turnoDelDialogo = 0;
	bool interactuable=false;
	public SpriteRenderer playerR;
	public InvertLayer invL;
    void Start()
    {
		playerR = target.GetComponent<SpriteRenderer> ();

    }

	void Update()
	{
		if (interactuable==true&& target!=null) {
			EnableTeleport ();
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.name==target.name) {
		interactuable = true;
        //EnableTeleport(other);
		}
    }
    private void OnTriggerStay2D(Collider2D other)
    {
     //   EnableText(other);

    }
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == target.name) {
			
			interactuable = false;
		}
	}

    private void EnableTeleport()
    {
   

		if (Input.GetKeyDown ("k")) {
			StartCoroutine (WaitForTransition (0.5f));
			if (invL != null) {
				if (invL.gameObject.tag == "FrontFacingD") {
					invL.Invert (playerR,this.gameObject); 
				}
			}
				target.transform.position = pos.position;

			
		}
        
    }
    private IEnumerator WaitForTransition(float waitTime)
    {

        fog.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        fog.SetActive(false);

    }
}
