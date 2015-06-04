using UnityEngine;
using System.Collections;

public enum MOVEMENTDIRECTION { UP, DOWN, LEFT, RIGHT, NONE };

public class NewPlayerMovement : MonoBehaviour 
{
	public static MOVEMENTDIRECTION movementDirection { get; private set; }
	public static MOVEMENTDIRECTION lookingTo;

	Animator anim;
	private int valorCambio;

	public GameObject blackPlane;
	
	public AudioClip attack;
	AudioSource audio;

	//MOVEMENT
	//-------------
	private Vector3 movement;
	private float speed;
	public float speedWalk = 3.5f;
	public float speedSneak = 1f;
	public float speedRun = 8f;

	private Rigidbody2D rigidBody;
	//-------------

	//ATTACK
	//-------------
	public GameObject attackObject;
	private int attackCounter = 0;
	private bool attacking = false;
	private bool attackingCounter = false;
	private Vector3 attackPosition;
	//-------------

	//LIFE
	//-------------
	public GameObject corpse;
	private int maxLife = 600;
	public static int life = 600;
	//-------------

	//INTERFACE	
	//-------------
	public GameObject heart100;
	public GameObject heart200;
	public GameObject heart300;
	public GameObject heart400;
	public GameObject heart500;
	public GameObject heart600;
	public GameObject knife;
	public GameObject sword;
	//-------------

	//INVENTORY	
	//-------------
	public GameObject inventory;
	public GameObject inventorySelection;
	private bool inventoryBoolean = false;

	public GameObject candilTexture;
	public GameObject playerLight;

	private Vector3 otherSlot1 = new Vector3(-1.27f, 1.31f, -8.4f);
	private Vector3 otherSlot2 = new Vector3(-0.16f, 1.31f, -8.4f);
	private Vector3 otherSlot3 = new Vector3(0.98f, 1.31f, -8.4f);
	private Vector3 otherSlot4 = new Vector3(2.12f, 1.31f, -8.4f);
	private Vector3 otherSlot5 = new Vector3(-1.27f, -0.02f, -8.4f);
	private Vector3 otherSlot6 = new Vector3(-0.16f, -0.02f, -8.4f);
	private Vector3 otherSlot7 = new Vector3(0.98f, -0.02f, -8.4f);
	private Vector3 otherSlot8 = new Vector3(2.12f, -0.02f, -8.4f);
	private Vector3 otherSlot9 = new Vector3(-1.27f, -1.35f, -8.4f);
	private Vector3 otherSlot10 = new Vector3(-0.16f, -1.35f, -8.4f);
	private Vector3 otherSlot11 = new Vector3(0.98f, -1.35f, -8.4f);
	private Vector3 otherSlot12 = new Vector3(2.12f, -1.35f, -8.4f);

	private Vector3 equipedSlot1 = new Vector3(-3.547f, 1.42f, -8.4f);
	private Vector3 equipedSlot2 = new Vector3(-4.295f, -0.157f, -8.4f);
	private Vector3 equipedSlot3 = new Vector3(-2.83f, -0.157f, -8.4f);
	private Vector3 equipedSlot4 = new Vector3(-3.547f, -1.512f, -8.4f);

	private Vector3 specialSlot1 = new Vector3(-2.384f, -3.303f, -8.4f);
	private Vector3 specialSlot2 = new Vector3(-1.134f, -3.303f, -8.4f);
	private Vector3 specialSlot3 = new Vector3(0.102f, -3.303f, -8.4f);
	private Vector3 specialSlot4 = new Vector3(1.283f, -3.303f, -8.4f);
	private Vector3 specialSlot5 = new Vector3(2.515f, -3.303f, -8.4f);
	private Vector3 specialSlot6 = new Vector3(3.673f, -3.303f, -8.4f);
	//-------------

	void Start () 
	{		
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();

		blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 1);

		movement = Vector3.zero;
		
		movementDirection = MOVEMENTDIRECTION.DOWN;
		lookingTo = MOVEMENTDIRECTION.DOWN;
		
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		inventorySelection.transform.position = otherSlot1 + this.gameObject.transform.position;

		playerLight.SetActive(false);
	}

	void Update () 
	{
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  transform.position.y / 100.0f - 1.0f);

		if (inventoryBoolean == false)
		{
			attackPosition = this.gameObject.transform.position;

			//MOVEMENT
			//-------------
			Movement();
		
			if (Input.GetKey(KeyCode.C))
				speed = speedRun;
			else if (Input.GetKey(KeyCode.V))
				speed = speedSneak;
			else
				speed = speedWalk;
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

			//INTERFACE
			//-------------
			Interface ();
			//-------------
		}	
		//INVENTORY
		//-------------
		Inventory ();
		//-------------
	}

	void Movement()
	{
		bool isMoving = true;
		
		// Calculates the module of the speed
		float root = Mathf.Sqrt(speed * speed / 2);

		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) 
		{
			rigidBody.velocity = (new Vector2 (-root, root));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 11;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) 
		{
			rigidBody.velocity = (new Vector2 (root, root));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 11;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) 
		{
			rigidBody.velocity = (new Vector2 (-root, -root));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 1;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) 
		{
			rigidBody.velocity = (new Vector2 (root, -root));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 1;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.W)) 
		{
			rigidBody.velocity = (new Vector2 (0, speed));
			movementDirection = MOVEMENTDIRECTION.UP;

			valorCambio = 11;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 11;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.A)) 
		{
			rigidBody.velocity = (new Vector2 (-speed, 0));
			movementDirection = MOVEMENTDIRECTION.LEFT;

			valorCambio = 21;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 22;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.S)) 
		{
			rigidBody.velocity = (new Vector2 (0, -speed));
			movementDirection = MOVEMENTDIRECTION.DOWN;

			valorCambio = 1;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 1;
			anim.SetInteger("Transition", valorCambio);
		} else if (Input.GetKey (KeyCode.D)) 
		{
			rigidBody.velocity = (new Vector2 (speed, 0));
			movementDirection = MOVEMENTDIRECTION.RIGHT;

			valorCambio = 31;
			if (Input.GetKey(KeyCode.C))
				valorCambio = 32;
			anim.SetInteger("Transition", valorCambio);
		} else 
		{
			rigidBody.velocity = Vector2.zero;
			
			isMoving = false;
			movementDirection = MOVEMENTDIRECTION.NONE;

			switch (lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				valorCambio = 10;
				anim.SetInteger("Transition", valorCambio);
				break;
			case MOVEMENTDIRECTION.DOWN:
				valorCambio = 0;
				anim.SetInteger("Transition", valorCambio);
				break;
			case MOVEMENTDIRECTION.LEFT:
				valorCambio = 20;
				anim.SetInteger("Transition", valorCambio);
				break;
			case MOVEMENTDIRECTION.RIGHT:
				valorCambio = 30;
				anim.SetInteger("Transition", valorCambio);
				break;
			}
		}
		
		if (movementDirection != MOVEMENTDIRECTION.NONE)
			lookingTo = movementDirection;

		movement = Vector2.zero;
	}

	void Attack()
	{
		audio.PlayOneShot(attack, 1);

		switch (lookingTo)
		{
		case MOVEMENTDIRECTION.UP:
			Instantiate (attackObject, new Vector3(attackPosition.x, attackPosition.y + 0.67f, attackPosition.z), transform.rotation);
			valorCambio = 50;
			anim.SetInteger("Transition", valorCambio);
			break;
		case MOVEMENTDIRECTION.DOWN:
			Instantiate (attackObject, new Vector3(attackPosition.x, attackPosition.y - 1.4f, attackPosition.z), transform.rotation);
			valorCambio = 40;
			anim.SetInteger("Transition", valorCambio);
			break;
		case MOVEMENTDIRECTION.LEFT:
			Instantiate (attackObject, new Vector3(attackPosition.x - 0.67f, attackPosition.y, attackPosition.z), transform.rotation);
			valorCambio = 40;
			anim.SetInteger("Transition", valorCambio);
			break;
		case MOVEMENTDIRECTION.RIGHT:
			Instantiate (attackObject, new Vector3(attackPosition.x + 0.67f, attackPosition.y, attackPosition.z), transform.rotation);
			valorCambio = 50;
			anim.SetInteger("Transition", valorCambio);
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
			Destroy(gameObject);
			Instantiate(corpse);
		}

		//probar con mover rigid body

		if(EnemyAttack.hurt == true)
		{
			switch (lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				transform.position += new Vector3(0,-0.5f,0);
				break;
			case MOVEMENTDIRECTION.DOWN:
				transform.position += new Vector3(0,0.5f,0);
				break;
			case MOVEMENTDIRECTION.LEFT:
				transform.position += new Vector3(0.5f,0,0);
				break;
			case MOVEMENTDIRECTION.RIGHT:
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

	void Inventory()
	{
		if(Input.GetKeyDown(KeyCode.Space) && inventoryBoolean == false)
		{
			inventory.SetActive(true);
			inventorySelection.SetActive(true);
			inventoryBoolean = true;
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space) && inventoryBoolean == true)
		{
			inventory.SetActive(false);
			inventorySelection.SetActive(false);
			inventoryBoolean = false;
			return;
		}

		if (inventoryBoolean == true) 
		{
			if(Candil.candil == true)
			{
				candilTexture.transform.position = specialSlot1 + this.gameObject.transform.position;
				//playerLight.SetActive(true);
			}

			if(inventorySelection.transform.position == otherSlot1 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = equipedSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = specialSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot5 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot2 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = specialSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot6 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot3 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = specialSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot7 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot4 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = equipedSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = specialSlot5 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot8 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot5 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot6 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = equipedSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot9 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot6 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot7 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot5 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot10 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot7 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot8 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot6 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot11 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot8 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = equipedSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot7 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot12 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot9 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot10 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = equipedSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot5 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = specialSlot2 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot10 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot11 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot9 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot6 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = specialSlot3 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot11 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot12 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot10 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot7 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = specialSlot4 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == otherSlot12 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = equipedSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot11 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot8 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = specialSlot5 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == equipedSlot1 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = specialSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = equipedSlot2 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == equipedSlot2 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = equipedSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot8 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = equipedSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = equipedSlot4 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == equipedSlot3 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot5 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = equipedSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = equipedSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = equipedSlot4 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == equipedSlot4 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = otherSlot9 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = otherSlot12 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = equipedSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = specialSlot1 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot1 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot6 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = equipedSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = equipedSlot1 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot2 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot9 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot1 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot3 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot2 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot10 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot2 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot4 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot5 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot3 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot11 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot3 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot5 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot6 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot4 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.W)) 
				{
					inventorySelection.transform.position = otherSlot12 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.S)) 
				{
					inventorySelection.transform.position = otherSlot4 + this.gameObject.transform.position;
				}
				return;
			}

			if(inventorySelection.transform.position == specialSlot6 + this.gameObject.transform.position)
			{
				if (Input.GetKeyDown (KeyCode.D)) 
				{
					inventorySelection.transform.position = specialSlot1 + this.gameObject.transform.position;
				} else if (Input.GetKeyDown (KeyCode.A)) 
				{
					inventorySelection.transform.position = specialSlot5 + this.gameObject.transform.position;
				}
				return;
			}
		}
	}
}