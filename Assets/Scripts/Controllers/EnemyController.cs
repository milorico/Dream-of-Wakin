using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class EnemyController : MonoBehaviour {

	public float enemyLife=600;
	public float enemyDamage= 26;

	public float m_MaxSpeed = 3f;            
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
	public GameObject attackObject;
	int randomX;
	int randomY;
	private bool esquivar = false;
	private bool patrullar= false;
	private int esqVal =0;
	public bool atacar =false;
	public bool recibirDanio =false;
	// Use this for initialization
	private void Awake(){
		patrullar = true;
		player = GameObject.Find ("Player");
		mySriteRenderer = GetComponent<SpriteRenderer> ();
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		if(attackObject!=null){
		attackObject.SetActive(false);
	}
	}

	// Update is called once per frame
	void FixedUpdate () {
		enemyDamage = enemyDamage;
		if (enemyLife<=0) {
			Destroy (this.gameObject);	
		}
		if (player!=null) {
			
		
			pPosition = new Vector2 (player.transform.position.x, player.transform.position.y);
		}
		if (esquivar == true) {
		//	pPosition = new Vector2 (player.transform.position.x + EsquivarCentroX(), player.transform.position.y+EsquivarCentroY());
		} else {
			
		}
		//	
		float h = pPosition.x - transform.position.x;
		float j = pPosition.y - transform.position.y;
		if (atacar == true) {
			if(attackObject!=null){
			Attack2(h,j,attackObject);}
			else{
			Attack2 (h, j);}
		} else {
			if (patrullar ==true) {
             Patrullar(h,j);
			}
			Move (h, j);

		}
		ActAnimator (h, j);
		i++;
	}
	public void Move(float move,float move2)
	{
		if(followPlayer==true){
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed*0, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = new Vector2(move2*m_MaxSpeed*0, m_Rigidbody2D.velocity.x);
		
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
		attackPosition = pPosition;
		int random = Random.Range (1, 200);
		//print (random);
		if (random<3) {
			atacar = true;
		}
	}
		//print (m_Rigidbody2D.velocity);
	}

	public virtual void Attack2(float move, float move2){
		if(followPlayer == true){
			if (m_Anim.runtimeAnimatorController != null) {
				m_Anim.SetTrigger ("Attaking");
			}
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x,
			transform.position.y), attackPosition, m_MaxSpeed * Time.deltaTime);
		if (transform.position.x==attackPosition.x || i>150) {
			atacar = false;
			i = 0;
		}
	}
	}
	public virtual void Attack2(float move, float move2,GameObject attackRange){
		if(followPlayer == true){
			if (m_Anim.runtimeAnimatorController != null) {
				m_Anim.SetTrigger ("Attaking");
			}
		attackRange.SetActive(true);
		attackRange.transform.position = Vector2.MoveTowards (new Vector2 (attackRange.transform.position.x,
			attackRange.transform.position.y), attackPosition, 12f * Time.deltaTime);
		if (transform.position.x==attackPosition.x || i>150) {
			atacar = false;
			attackRange.SetActive(false);
			attackRange.transform.position = transform.position;
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
			patrullar=false;	
			//print ("esquivando");
		//	esquivar = true;
		}
		//DejarDeSeguir();
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

		StartCoroutine( WaitForSeguir(0.6f));
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
		int random = Random.Range (1, 200);
		if (girar > 100) {
			randomX = Random.Range (-1, 2);
			randomY = Random.Range (-1, 2);
		}
		m_Rigidbody2D.velocity = new Vector2(randomX, randomY);
		if (m_Rigidbody2D.velocity.x>0) {
			mySriteRenderer.flipX = true;
		}
		else {
			mySriteRenderer.flipX = false;
		}
        if(girar<100){
		 m_Rigidbody2D.velocity =new Vector2(randomX, randomY);
		
		}else if(random >50)
{
			m_Rigidbody2D.velocity =new Vector2(randomX, randomY);
			if(girar>101){
				girar=0;
			}
		}girar++;

}
	public void RecibirDanio(){
		if(m_Anim.runtimeAnimatorController!=null){
		m_Anim.SetTrigger ("Damage");
	}
	}
	private IEnumerator WaitForSeguir(float waitTime){
		yield return new WaitForSeconds (waitTime);
		followPlayer = false;
		patrullar = true;
		atacar = false;
	}
	public void ActAnimator(float move, float move2){
		if (m_Anim.runtimeAnimatorController != null) {
			m_Anim.SetFloat ("PlayerDifferenceX", move);
			m_Anim.SetFloat ("PlayerDifferenceY", move2);
			m_Anim.SetFloat ("DirectionX", m_Rigidbody2D.velocity.x);
			m_Anim.SetFloat ("DirectionY", m_Rigidbody2D.velocity.y);
		}
	}
}	
