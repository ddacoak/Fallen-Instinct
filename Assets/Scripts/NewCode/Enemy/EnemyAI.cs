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

	//LIFE
	//-------------
	public int life = 300;
	//-------------
	
	void Start()
	{
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
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
		Movement ();
		anim.SetInteger("Transition", valorCambio);
		//-------------

		//LIFE
		//-------------
		Life ();
		//-------------
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
			Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			life -= 75;

			switch (NewPlayerMovement.lookingTo)
			{
			case MOVEMENTDIRECTION.UP:
				transform.position += new Vector3(0,0.5f,0);
				break;
			case MOVEMENTDIRECTION.DOWN:
				transform.position += new Vector3(0,-0.5f,0);
				break;
			case MOVEMENTDIRECTION.LEFT:
				transform.position += new Vector3(-0.5f,0,0);
				break;
			case MOVEMENTDIRECTION.RIGHT:
				transform.position += new Vector3(0.5f,0,0);
				break;
			}
		}
	}
}
