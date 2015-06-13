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
	private bool dead = false;
	private int deadCounter = 0;
	//-------------

	//CEPO
	//-------------
	public AudioClip cepo;
	AudioSource audio;

	private bool trapped = false;
	private bool modifyEnemy = false;
	public static bool enemyHurt = false;

	public GameObject bloodPs;
	public GameObject cepos;
	//-------------
	
	void Start()
	{
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
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

			if (player.transform.position.y >= transform.position.y)
			{
				valorCambio = 3;
			}
			else if (player.transform.position.y <= transform.position.y)
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
		//-------------

		anim.SetInteger("Transition", valorCambio);
	}

	void Movement()
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);
		float viewDistance2 = Vector3.Distance(player.transform.position, transform.position);
		valorCambio = 0;

		if (viewDistance <= range) 
		{
			if (player.transform.position.x >= transform.position.x)
			{
				//rigidBody.velocity = (new Vector2(speed, 0));
				transform.position += new Vector3(speed,0,0) * Time.deltaTime;
				valorCambio = 2;
			}
			else if (player.transform.position.x <= transform.position.x)
			{
				//rigidBody.velocity = (new Vector2(-speed, 0));
				transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			
			if (player.transform.position.y >= transform.position.y)
			{
				//rigidBody.velocity = (new Vector2(0, speed));
				transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			else if (player.transform.position.y <= transform.position.y)
			{
				//rigidBody.velocity = (new Vector2(0, -speed));
				transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
				valorCambio = 1;
			}
		}

		if (viewDistance2 <= range2 && viewDistance >= range) 
		{
			if (player.transform.position.x >= transform.position.x)
			{
				//rigidBody.velocity = (new Vector2(speed, 0));
				transform.position += new Vector3(speed2,0,0) * Time.deltaTime;
				valorCambio = 2;
			}
			else if (player.transform.position.x <= transform.position.x)
			{
				//rigidBody.velocity = (new Vector2(-speed, 0));
				transform.position += new Vector3(-speed2, 0, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			
			if (player.transform.position.y >= transform.position.y)
			{
				//rigidBody.velocity = (new Vector2(0, speed));
				transform.position += new Vector3(0, speed2, 0) * Time.deltaTime;
				valorCambio = 1;
			}
			else if (player.transform.position.y <= transform.position.y)
			{
				//rigidBody.velocity = (new Vector2(0, -speed));
				transform.position += new Vector3(0, -speed2, 0) * Time.deltaTime;
				valorCambio = 1;
			}
		}
	}

	void Life()
	{
		if (life <= 0)
		{
			deadCounter++;
			valorCambio = 5;
			dead = true;
			if (deadCounter >= 30)
				Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			life -= 75;

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
	}

	void TrappedZombi()
	{
		trapped = true;
		life -= 50;
		Instantiate(bloodPs, new Vector3 (transform.position.x, transform.position.y + 1.2f, -1), Quaternion.Euler(0, 0, 0));
	}
}
