using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;
    public float spwanTime;
    public GameObject spwaner;
    public GameObject bulletPrefab;
    private float counter;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;

        if (counter > spwanTime)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, spwaner.transform, true);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, bullet.GetComponent<Rigidbody2D>().velocity.y);
            counter = 0;
        }
	}
}
