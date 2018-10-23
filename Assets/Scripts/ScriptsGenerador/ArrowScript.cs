using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour {

    //estas son las fichas del puzzle
    public GameObject tokenSun;
    public GameObject tokenMoon;
    public GameObject tokenFlake;
    public GameObject tokenLeaf;
    public GameObject tokenFlower;

    //en este vector se guardan las fichas 
    GameObject[] tokenPosition;

    //Variables auxiliares para manipular las fichas dentro del vector y su posicion
    GameObject tokenAux;
    GameObject tokenAux2;

    //variables de la flecha de seleccion de la ficha que cambiara de lugar
    int arrowPosition;
    int arrowSelect;
    bool tokenSelect;

    //camaras para cambiar entre el puzzle y el mapa principal
    public Camera camPuzzle;
    public Camera camMain;

    //variable para abrir la puerta
    public bool openDoor;


    void Start () 
    {
       
        arrowPosition = 2;
        arrowSelect = 0;
        tokenSelect = false;
        tokenPosition = new GameObject [5];
        tokenPosition[0] = tokenSun;
        tokenPosition[1] = tokenMoon;
        tokenPosition[2] = tokenFlake;
        tokenPosition[3] = tokenLeaf;
        tokenPosition[4] = tokenFlower;
        tokenAux = null;
        
        camPuzzle.GetComponent<Camera>().enabled = true;
        camMain.GetComponent<Camera>().enabled = false;
        
        openDoor = false;

       
    }
	
	void Update ()
	{
		if (openDoor == false) {
			
		
			if (Input.GetKeyDown (KeyCode.J)) {
				tokenSelect = true;
				arrowSelect = arrowPosition;
			}

			if ((Input.GetKeyDown (KeyCode.D)) & (transform.position.x < 2.2)) {

				transform.position = new Vector3 (transform.position.x + 1.1f, transform.position.y, transform.position.z);
				arrowPosition++;

				if (tokenSelect) {

					//creo un clon de la ficha a amover
					tokenAux = Instantiate (tokenPosition [arrowSelect]);
					tokenAux.transform.position = tokenPosition [arrowSelect].transform.position;
		
					//intercambio las pocisiones de las fichas
					tokenPosition [arrowSelect].transform.position = tokenPosition [arrowPosition].transform.position;
					tokenPosition [arrowPosition].transform.position = tokenAux.transform.position;
					tokenAux2 = tokenPosition [arrowSelect];

					//intercambio las pocisiones en el vector
					tokenPosition [arrowSelect] = tokenPosition [arrowPosition];
					tokenPosition [arrowPosition] = tokenAux2;
					tokenSelect = false;
					Destroy (tokenAux);
				}

			}
			if ((Input.GetKeyDown (KeyCode.A)) & (transform.position.x > -2.2)) {

				transform.position = new Vector3 (transform.position.x - 1.1f, transform.position.y, transform.position.z);
				arrowPosition--;

				if (tokenSelect) {
					//creo un clon de la ficha a amover
					tokenAux = Instantiate (tokenPosition [arrowSelect]);
					tokenAux.transform.position = tokenPosition [arrowSelect].transform.position;

					//intercambio las pocisiones de las fichas
					tokenPosition [arrowSelect].transform.position = tokenPosition [arrowPosition].transform.position;
					tokenPosition [arrowPosition].transform.position = tokenAux.transform.position;
					tokenAux2 = tokenPosition [arrowSelect];

					//intercambio las pocisiones en el vector
					tokenPosition [arrowSelect] = tokenPosition [arrowPosition];
					tokenPosition [arrowPosition] = tokenAux2;
					tokenSelect = false;
					Destroy (tokenAux);

				}
			}

			for (int i = 0; i <= 4; i++) {	


				TokenScript script = tokenPosition [i].GetComponent<TokenScript> ();

				if (!script.checkCorrectPosition) {	
					//print("break");
					break;
				}

				if (i == 4) {
					camPuzzle.GetComponent<Camera> ().enabled = false;
					camMain.GetComponent<Camera> ().enabled = true;
					DontDestroyOnLoad (this.gameObject);
					openDoor = true;
					Time.timeScale = 1.00f;
					SceneManager.UnloadSceneAsync ("Generator");
                
               

				}
			}
		}
	}
}
