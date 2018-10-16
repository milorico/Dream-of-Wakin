using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	public void CambioDeScena  (string NombreDeScena) {

        SceneManager.LoadScene("HutRoom");


    }
	
	
}
