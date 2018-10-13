using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextInCollider : MonoBehaviour {

    public GameObject target;
    public GameObject TextThatAppearsWhenInteracted;
    int turnoDelDialogo = 0;
   
    void Start()
    {
        TextThatAppearsWhenInteracted.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == target.name)
        {
            TextThatAppearsWhenInteracted.SetActive(false);
        }
    }
    private void EnableText(Collider2D other)
    {
        if (other.name == target.name)
        {


                TextThatAppearsWhenInteracted.SetActive(true);
           
        }
    }
}
