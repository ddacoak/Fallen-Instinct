using UnityEngine;
using System.Collections;

public enum MOVEMENTDIRECTION { UP, DOWN, LEFT, RIGHT, NONE };

public class NewPlayerMovement : MonoBehaviour 
{
	public static MOVEMENTDIRECTION movementDirection { get; private set; }
	public static MOVEMENTDIRECTION lookingTo;

	Animator anim;
	public int valorCambio;

	public GameObject blackPlane;
	
	public AudioClip attack;
	public AudioClip walk;
	public AudioClip run;
	AudioSource audio;

	//MOVEMENT
	//-------------
	private Vector3 movement;
	private float speed;
	public float speedWalk = 3.5f;
	public float speedSneak = 1f;
	public float speedRun = 8f;

	private bool isMoving = false;

	public GameObject walking;
	public GameObject running;

	private Rigidbody2D rigidBody;
	//-------------

	//ATTACK
	//-------------
	public GameObject attackObject;
	private int attackCounter = 0;
	private bool attacking = false;
	private bool attackingCounter = false;
	public static bool missedAttack = true;
	private Vector3 attackPosition;
	//-------------

	//LIFE
	//-------------
	public static int maxLife = 600;
	public static int life = 600;
	public static bool dead = false;
	//-------------

	//LIGHT
	//-------------
	public GameObject playerLight;
	//-------------

	//INTERFACE	
	//-------------
	public GameObject heart100;
	public GameObject heart200;
	public GameObject heart300;
	public GameObject heart400;
	public GameObject heart500;
	public GameObject heart600;
	//-------------
	
	void Start () 
	{		
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();

		audio.clip = walk;

		blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 1);

		movement = Vector3.zero;
		
		movementDirection = MOVEMENTDIRECTION.DOWN;
		lookingTo = MOVEMENTDIRECTION.DOWN;
		
		rigidBody = transform.GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  transform.position.y / 100.0f - 1.0f);

		attackPosition = this.gameObject.transform.position;

		anim.SetInteger("Transition", valorCambio);

		//MOVEMENT
		//-------------
		Movement();

		if (Input.GetKey (KeyCode.C) || Input.GetKey (KeyCode.LeftShift)) 
		{
			speed = speedRun;
		}
		else if (Input.GetKey(KeyCode.V))
			speed = speedSneak;
		else
		{
			speed = speedWalk;
		}



		if (Input.GetKey (KeyCode.C)|| Input.GetKey (KeyCode.LeftShift))
		{
			audio.clip = run;
		}else
			audio.clip = walk;

		/*if (isMoving == true)
		{
			audio.Play ();
		}

		if (isMoving == false)
		{
			audio.Stop ();
		}*/
		//-------------

		//ATTACK
		//-------------
		attackObject.transform.position = transform.position;

		if (Input.GetKeyDown (KeyCode.I) && attackingCounter == false)
		{
			attackingCounter = true;
			attacking = true;
			if (attacking == true) 
			{
				Attack();
			}
			attackCounter++;
		}

		if (attackingCounter == true)
		{
			attackCounter++;
			if (attackCounter >= 15)
			{
				attackingCounter = false;
				attackCounter = 0;
			}
		}
		//-------------

		//LIFE
		//-------------
		Life ();
		//-------------

		//LIGHT
		//-------------
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			Candil.candil = true;
			Candil.oilCounter = 200;
			playerLight.SetActive(true);
		}
		//-------------

		//INTERFACE
		//-------------
		Interface ();
		//-------------
	

	}

	void Movement()
	{
		// Calculates the module of the speed
		float root = Mathf.Sqrt(speed * speed / 2);

		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (-root, root));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 12;

		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (root, root));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 12;

		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (-root, -root));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 2;

		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (root, -root));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 2;

		} else if (Input.GetKey (KeyCode.W)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (0, speed));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 12;

		} else if (Input.GetKey (KeyCode.A)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (-speed, 0));
			movementDirection = MOVEMENTDIRECTION.LEFT;

			valorCambio = 21;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 22;

		} else if (Input.GetKey (KeyCode.S)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (0, -speed));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 2;

		} else if (Input.GetKey (KeyCode.D)) 
		{
			isMoving = true;
			rigidBody.velocity = (new Vector2 (speed, 0));
			movementDirection = MOVEMENTDIRECTION.RIGHT;

			valorCambio = 31;
			if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftShift))
				valorCambio = 32;

		} else 
		{
			rigidBody.velocity = Vector2.zero;
			
			isMoving = false;
			movementDirection = MOVEMENTDIRECTION.NONE;

			switch (lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				valorCambio = 10;

				break;
			case MOVEMENTDIRECTION.DOWN:
				valorCambio = 0;

				break;
			case MOVEMENTDIRECTION.LEFT:
				valorCambio = 20;

				break;
			case MOVEMENTDIRECTION.RIGHT:
				valorCambio = 30;

				break;
			}
		}
		
		if (movementDirection != MOVEMENTDIRECTION.NONE)
			lookingTo = movementDirection;

		movement = Vector2.zero;
	}

	void Attack()
	{
		//if (missedAttack == true)
			audio.PlayOneShot(attack, 1);

		switch (lookingTo)
		{
		case MOVEMENTDIRECTION.UP:
			Instantiate (attackObject, new Vector3(attackPosition.x, attackPosition.y + 0.25f, attackPosition.z), transform.rotation);
			valorCambio = 70;

			break;
		case MOVEMENTDIRECTION.DOWN:
			Instantiate (attackObject, new Vector3(attackPosition.x, attackPosition.y - 1.0f, attackPosition.z), transform.rotation);
			valorCambio = 60;

			break;
		case MOVEMENTDIRECTION.LEFT:
			Instantiate (attackObject, new Vector3(attackPosition.x - 1.0f, attackPosition.y-0.2f, attackPosition.z), transform.rotation);
			valorCambio = 40;

			break;
		case MOVEMENTDIRECTION.RIGHT:
			Instantiate (attackObject, new Vector3(attackPosition.x + 1.0f, attackPosition.y-0.2f, attackPosition.z), transform.rotation);
			valorCambio = 50;

			break;
		}

		attacking = false;
	}
	public void Life()
	{
		if (life >= maxLife)
			life = maxLife;

		if (life <= 0) 
		{
			dead = true;
		}

		if (Input.GetKeyDown (KeyCode.G))
			life = maxLife;

		if(EnemyAttack.hurt == true)
		{
			switch (lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				valorCambio = 23;

				transform.position += new Vector3(0,-0.5f,0);
				break;
			case MOVEMENTDIRECTION.DOWN:
				valorCambio = 33;

				transform.position += new Vector3(0,0.5f,0);
				break;
			case MOVEMENTDIRECTION.LEFT:
				valorCambio = 23;

				transform.position += new Vector3(0.5f,0,0);
				break;
			case MOVEMENTDIRECTION.RIGHT:
				valorCambio = 33;

				transform.position += new Vector3(-0.5f,0,0);
				break;
			}

			EnemyAttack.hurt = false;
		}
	}

	void Interface()
	{
		if (life >= 600)
			heart600.SetActive (true);
		else
			heart600.SetActive (false);
		if (life >= 500)
			heart500.SetActive (true);
		else
			heart500.SetActive (false);
		if (life >= 400)
			heart400.SetActive (true);
		else
			heart400.SetActive (false);
		if (life >= 300)
			heart300.SetActive (true);
		else
			heart300.SetActive (false);
		if (life >= 200)
			heart200.SetActive (true);
		else
			heart200.SetActive (false);
		if (life >= 100)
			heart100.SetActive (true);
		else
			heart100.SetActive (false);
	}
}