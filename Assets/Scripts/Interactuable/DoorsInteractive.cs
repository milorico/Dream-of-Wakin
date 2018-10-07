using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsInteractive : MonoBehaviour {
    public Transform pos;
    public GameObject target;
    bool Pause = true;
 
    int turnoDelDialogo = 0;
   
    void Start()
    {
        
    }

   
  
    private void OnTriggerEnter2D(Collider2D other)
    {

        EnableText(other);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        EnableText(other);

    }
   
    private void EnableText(Collider2D other)
    {
        if (other.name == target.name)
        {

            if (Input.GetKeyDown("k"))
            {

                target.transform.position = pos.position;
            }
        }
    }
}
