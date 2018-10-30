using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public KeyItemsProgress keyItems;
	public float playerLife=100;
	public Text lifeT;
	private float m_MaxSpeed = 3f;            
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool timer=true;
	public EnemyController enemyC;
	private CapsuleCollider2D enemyCollider;
	int tiempo;
	private void Awake(){
	//	enemyC = GameObject.FindWithTag ("Enemy").GetComponent<EnemyController> ();
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		lifeT.text = playerLife.ToString();
		float h = CrossPlatformInputManager.GetAxis("Vertical");
		float j = CrossPlatformInputManager.GetAxis("Horizontal");
		float k = CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");
		bool aiming = CrossPlatformInputManager.GetButton("Fire1");
		bool a = CrossPlatformInputManager.GetButton("Fire2");
		m_Anim.SetFloat ("DirectionX",h);
		m_Anim.SetFloat ("DirectionY", j);
		m_Anim.SetBool ("Aiming", aiming);
		Vector2 m_direction;
		m_direction = new Vector2 (j, h);

		if (playerLife<=0) {
			Destroy (this.gameObject);	
		}
		if (a == true && timer==true) {
			timer = false;
			m_Anim.SetTrigger ("Shoot");
			Shoot (m_direction);
		}
		if (aiming == true) {
			Aiming (h, j);
		}
		if (m_Anim.GetBool ("Aiming") == false) {
			Move (h, j);
		}
	}
	public void Move(float move,float move2)
	{
		m_Anim.SetFloat("Speed", Mathf.Abs(move));
		m_Anim.SetFloat("Speed2", Mathf.Abs(move2));
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = new Vector2(move2*m_MaxSpeed, m_Rigidbody2D.velocity.x);
		m_Anim.SetFloat ("Velocity", m_Rigidbody2D.velocity.x);
		m_Anim.SetFloat ("Velocity2", m_Rigidbody2D.velocity.y);
		//print (m_Rigidbody2D.velocity);
	}
	public void Aiming(float move,float move2)
	{
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed*0, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = new Vector2(move2*m_MaxSpeed*0, m_Rigidbody2D.velocity.x);
	}
	public void Shoot(Vector2 direction){
		int layerMask = 1 << 8;
		layerMask= ~layerMask;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, direction,Mathf.Infinity,layerMask);
		Debug.DrawRay (transform.position, direction, Color.green);
		if (hit.collider != null) {
			//enemyC =hit.collider.gameObject.GetComponent<EnemyController> ();
			print (hit.transform.tag);
			if (hit.transform.tag== "Enemy") {
				
				enemyC = hit.transform.gameObject.GetComponent<EnemyController> (); 
				enemyC.RecibirDanio ();
				enemyC.enemyLife = enemyC.enemyLife - 50f;
				print ("le di");
				print (timer);
			}
		}
		StartCoroutine(WaitForRecoil (0.5f));
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Enemy")==true) {
		print ("auch");
			ReceiveDamage (col,700);
		}
		
		//m_Rigidbody2D.AddForce( new Vector2 (-col.transform.position.x, -col.transform.position.y));
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("Enemy")==true) {
			print ("violadoo");
			ReceiveDamage (col,1000);
		}
	}
	public void ReceiveDamage( Collider2D move2,float multipier){
		//recibioDanio = true;
		StartCoroutine (WaitForDamage (2f));
		float h = move2.transform.position.x - transform.position.x;
		float j = move2.transform.position.y - transform.position.y;
		m_Rigidbody2D.AddForce (new Vector2(-h*multipier,-j*multipier));
		enemyC = move2.GetComponent<EnemyController> ();
		playerLife = playerLife - enemyC.enemyDamage;
		//enemyCollider = enemyC.GetComponent<CapsuleCollider2D> ();
		
		if (true) {
		//	enemyCollider.isTrigger = true;
		}//m_Rigidbody2D.velocity = new Vector2(-move*m_MaxSpeed, -m_Rigidbody2D.velocity.y);
		//m_Rigidbody2D.velocity = new Vector2(-move2*m_MaxSpeed, -m_Rigidbody2D.velocity.x);
	}
	private IEnumerator WaitForDamage(float waitTime){
		Physics2D.IgnoreLayerCollision(8, 9,true);
		yield return new WaitForSeconds (waitTime);
		Physics2D.IgnoreLayerCollision(8, 9,false);
	//	timer = true;

	}
	private IEnumerator WaitForRecoil(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timer = true;

	}
}
