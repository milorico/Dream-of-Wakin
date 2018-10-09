using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class EnemyController : MonoBehaviour {
	public float enemyLife=600;


	private float m_MaxSpeed = 3f;            
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private GameObject player;
	private Vector2 pPosition;
	private Vector2 attackPosition;
	private SpriteRenderer mySriteRenderer;
	private Collider2D attackCollider;
	private bool followPlayer;
	private int i;
	private float w;
	private float e;
	private int girar;
	private bool esquivar = false;
	private int esqVal =0;
	public bool atacar =false;
	public bool recibirDanio =false;
	// Use this for initialization
	private void Awake(){
		player = GameObject.Find ("Player");
		mySriteRenderer = GetComponent<SpriteRenderer> ();
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (enemyLife<=0) {
			Destroy (this.gameObject);	
		}
		if (esquivar == true) {
			pPosition = new Vector2 (player.transform.position.x + EsquivarCentroX(), player.transform.position.y+EsquivarCentroY());
		} else {
			pPosition = new Vector2 (player.transform.position.x , player.transform.position.y);
		}
		//	
		float h = pPosition.x - transform.position.x;
		float j = pPosition.y - transform.position.y;
		if (atacar == true) {
			Attack2 (h, j);
		} else {
			if (esquivar ==true) {

			}
			Move (h, j);
			Patrullar(h,j);
		}

		i++;
	}
	public void Move(float move,float move2)
	{
		if(followPlayer==true){
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed*0, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = new Vector2(move2*m_MaxSpeed*0, m_Rigidbody2D.velocity.x);
		m_Anim.SetFloat("Speed", move);
		m_Anim.SetFloat("Speed2", move2);
	

			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x,
			transform.position.y), pPosition, 1f * Time.deltaTime);
		if (move>0) {
			mySriteRenderer.flipX = true;
		}
		else {
			mySriteRenderer.flipX = false;
		}
		
		
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x,
				transform.position.y), pPosition, 1f * Time.deltaTime);
		
		m_Anim.SetFloat ("Velocity", m_Rigidbody2D.velocity.x);
		m_Anim.SetFloat ("Velocity2", m_Rigidbody2D.velocity.y);
		attackPosition = pPosition;
		int random = Random.Range (1, 200);
		//print (random);
		if (random<3) {
			atacar = true;
		}
	}
		//print (m_Rigidbody2D.velocity);
	}
	public void Attack2(float move, float move2){
		if(followPlayer = true){
		m_Anim.SetTrigger ("Attaking");
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x,
			transform.position.y), attackPosition, 3f * Time.deltaTime);
		if (transform.position.x==attackPosition.x || i>150) {
			atacar = false;
			i = 0;
		}
	}
	}
	void OnCollisionEnter2D(Collision2D col){
	//	print ("esquivando");
		if (col.gameObject.tag == "Centro") {
			
			//print ("esquivando");
			esquivar = true;
		}
	}
	void OnTriggerStay2D(Collider2D col){
	//	print ("esquivando");
		if (col.gameObject.tag == "Player") {
			followPlayer =true;
			//print ("esquivando");
		//	esquivar = true;
		}
		DejarDeSeguir();
	}
	void OnTriggerExit2D(Collider2D col){
	//	print ("esquivando");
		if (col.gameObject.tag == "Player") {
			DejarDeSeguir();
			//print ("esquivando");
			//esquivar = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
	//	print ("esquivando");

		if (col.gameObject.tag == "Centro") {
			print ("esquivando");
		esqVal = 0;
		esquivar = false;
			}
	}
	public int EsquivarCentroX(){
		//print ("esquivando");
		if (pPosition.x - transform.position.x < 0)
			return esqVal-=2;
		if (pPosition.x - transform.position.x > 0)
			return esqVal+=2;
		else {
			return 0;
		}
		//
	}
	public void DejarDeSeguir(){
		StartCoroutine( WaitForSeguir(3f));
	}
	public int EsquivarCentroY(){
		//print ("esquivando");
		if (pPosition.y - transform.position.y < 0)
			return esqVal-=2;
		if (pPosition.y - transform.position.y > 0)
			return esqVal+=2;
		else {
			return 0;
		}
		//
	}
	public void Patrullar(float move, float move2){
        m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed*0, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = new Vector2(move2*m_MaxSpeed*0, m_Rigidbody2D.velocity.x);
		m_Anim.SetFloat("Speed", move);
		m_Anim.SetFloat("Speed2", move2);
if(girar<200){
		transform.position =new Vector2 (-1,
			-1);
		i++;
}else if(girar>200)
{
			transform.position =new Vector2 (1,
			1);
			if(girar>400){
				girar=0;
			}
	}

}
	public void RecibirDanio(){
		m_Anim.SetTrigger ("Daño");
	}
	private IEnumerator WaitForSeguir(float waitTime){
		yield return new WaitForSeconds (waitTime);
		followPlayer = false;

	}
}	
