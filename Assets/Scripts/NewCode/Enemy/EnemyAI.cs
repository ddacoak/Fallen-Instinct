using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	//MOVEMENT
	//-------------
	public float speed = 0.5f;
	public float speed2 = 1f;
	private float range = 5.0f;
	private float range2 = 50.0f;
	private float rangeX = 0.49f;
	private float rangeY = 0.49f;
	public GameObject player;

	private Rigidbody2D rigidBody;

	public  bool modifyPosCorrect = true;

	Animator anim;
	private int valorCambio;
	//-------------

	//ATTACK
	//-------------
	private int attackCounter = 0;
	//-------------

	//LIFE
	//-------------
	public int life = 300;
	public int lifeMemory;
	private bool dead = false;
	private float deadCounter = 0;
	private bool stunned = false;
	private int stunnedCounter = 0;
	public AudioClip xof;
	//-------------

	//CEPO
	//-------------
	public AudioClip cepo;
	AudioSource audio;

	private bool trapped = false;
	private bool modifyEnemy = false;
	public static bool enemyHurt = false;

	public GameObject bloodPs;
	public GameObject bloodExplosionPs;
	public GameObject zombiPartsPs;
	public GameObject cepos;
	//-------------
	
	void Start()
	{
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
		lifeMemory = life;
	}

	void Update () 
	{
		if (modifyPosCorrect) {
			transform.position = new Vector3 (transform.position.x,
                                  			  transform.position.y,
		                                      transform.position.y / 100.0f - 1.0f);
		} else {
			transform.position = new Vector3 (transform.position.x,
			                                  transform.position.y,
			                                  transform.position.y / 100.0f + 1.0f);
		}

		//MOVEMENT
		//-------------
		if (dead == false)
			Movement ();
		//-------------

		//ATTACK
		//-------------
		if (EnemyAttack.hurt2 == true)
		{
			attackCounter++;

			if (player.transform.position.x >= transform.position.x)
			{
				valorCambio = 3;
			}
			else if (player.transform.position.x <= transform.position.x)
			{
				valorCambio = 4;
			}

			if (attackCounter >= 10) 
			{
				attackCounter = 0;
				EnemyAttack.hurt2 = false;
			}
		}
		//-------------

		//LIFE
		//-------------
		Life ();

		if (stunned == true)
		{
			stunnedCounter++;

			if (player.transform.position.x >= transform.position.x)
			{
				valorCambio = 6;
			}
			else if (player.transform.position.x <= transform.position.x)
			{
				valorCambio = 7;
			}

			if (stunnedCounter >= 20) 
			{
				stunned = false;

				stunnedCounter = 0;
			}
				
		}
		//-------------

		if (dead) valorCambio = 5;
		anim.SetInteger("Transition", valorCambio);
	}

	void Movement()
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);
		float viewDistance2 = Vector3.Distance(player.transform.position, transform.position);
		valorCambio = 0;

		if (viewDistance <= range) 
		{
			if (player.transform.position.x >= transform.position.x + rangeX)
			{
				transform.position += new Vector3(speed,0,0) * Time.deltaTime;
				valorCambio = 2;
			}
			else if (player.transform.position.x < transform.position.x - rangeX)
			{
				transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			/*if (rangeX >= player.transform.position.x - transform.position.x)
			{
				transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
			}*/
			
			if (player.transform.position.y >= transform.position.y)
			{
				transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
			}
			else if (player.transform.position.y < transform.position.y)
			{
				transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
			}
			/*if (rangeY >= player.transform.position.y - transform.position.y)
			{
				Debug.Log ("entra Y");
				transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
			}*/
		}

		if (viewDistance2 <= range2 && viewDistance >= range) 
		{
			if (player.transform.position.x >= transform.position.x)
			{
				transform.position += new Vector3(speed2,0,0) * Time.deltaTime;
				valorCambio = 2;
			}
			else if (player.transform.position.x <= transform.position.x)
			{
				transform.position += new Vector3(-speed2, 0, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			
			if (player.transform.position.y >= transform.position.y)
			{
				transform.position += new Vector3(0, speed2, 0) * Time.deltaTime;
			}
			else if (player.transform.position.y <= transform.position.y)
			{
				transform.position += new Vector3(0, -speed2, 0) * Time.deltaTime;
			}
		}
		if (dead) valorCambio = 5;
	}

	void Life()
	{
		if (lifeMemory != life) 
		{
			Instantiate(bloodPs, new Vector3 (transform.position.x, 
			                                  transform.position.y,
			                                  -1), 
			            					  Quaternion.Euler(0, 0, 0));

			Instantiate(zombiPartsPs, new Vector3 (transform.position.x, 
			                                  transform.position.y,
			                                  -1), 
			            					  Quaternion.Euler(0, 0, 0));
		}

		if (life <= 0)
		{
			deadCounter += Time.deltaTime;
			valorCambio = 5;
			if(!dead) Instantiate(bloodExplosionPs, new Vector3 (transform.position.x, 
			                                                     transform.position.y,
			                                                     -1), 
			                      								 Quaternion.Euler(0, 0, 0));
			dead = true;
			if (deadCounter >= 0.6)
				Destroy (this.gameObject);
		}
		lifeMemory = life;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			life -= 75;

			stunned = true;

			audio.PlayOneShot(xof, 1f);

			switch (NewPlayerMovement.lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				transform.position += new Vector3(0,0.4f,0);
				break;
			case MOVEMENTDIRECTION.DOWN:
				transform.position += new Vector3(0,-0.4f,0);
				break;
			case MOVEMENTDIRECTION.LEFT:
				transform.position += new Vector3(-0.4f,0,0);
				break;
			case MOVEMENTDIRECTION.RIGHT:
				transform.position += new Vector3(0.4f,0,0);
				break;
			}
		}

		if(other.tag == "Cepo")
		{
			TrappedZombi();
			enemyHurt = true;
		}
		if (dead) valorCambio = 5;
	}

	void TrappedZombi()
	{
		trapped = true;
		life -= 50;
		Instantiate(bloodPs, new Vector3 (transform.position.x, transform.position.y + 1.2f, -1), Quaternion.Euler(0, 0, 0));
	}
}
