using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cepos : MonoBehaviour 
{
	static Animator anim;
	public static int valorCambio = 0;

	//public GameObject playerShadow;
	public float range = 0.25f;
	public GameObject player;

	public AudioClip cepo;
	public AudioClip hurtSound;
	AudioSource audio;

	private bool hurt = true;

	public GameObject hurtFeedback;
	private float imageAlpha;

	private bool modifyPlayer = false;
	public float speed;
	public GameObject bloodPs;

	private int freePlayer = 600;
	private int freeCounter = 0;
	private int counterLower = 5;
	private int counterSpeed = 100;

	private float framesCounter = 0;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();

		imageAlpha = hurtFeedback.GetComponent<HurtFeedback> ().framesCounter;
	}

	void Update () 
	{
		if (modifyPlayer) {
			if(player.transform.position.x < transform.position.x)
			{
				player.transform.position = new Vector3 (player.transform.position.x + speed,
				                                         player.transform.position.y,
				                                         player.transform.position.z);
			}
			if(player.transform.position.x > transform.position.x) 
			{
				player.transform.position = new Vector3 (player.transform.position.x - speed,
				                                         player.transform.position.y,
				                                         player.transform.position.z);
			}
			if(player.transform.position.y < transform.position.y + 1.2)
			{
				player.transform.position = new Vector3 (player.transform.position.x,
				                                         player.transform.position.y + speed,
				                                         player.transform.position.z);
			}
			if(player.transform.position.y > transform.position.y + 1.2)
			{
				player.transform.position = new Vector3 (player.transform.position.x,
				                                         player.transform.position.y - speed,
				                                         player.transform.position.z);
			}

			if((player.transform.position.x <= transform.position.x + 0.3 && player.transform.position.x >= transform.position.x - 0.3)
			   &&(player.transform.position.y <= (transform.position.y + 1.2) + 0.3 && player.transform.position.y >= (transform.position.y + 1.2) - 0.3)) 
			{
				player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.2f, player.transform.position.z);
			}

			if (freeCounter > 0)
			{ 
				freeCounter -= counterLower;
				framesCounter += Time.deltaTime/4;
				if(framesCounter >= 1.0f)
				{
					framesCounter = 0.0f;
					hurt = true;
				}
			
			}
			else
			{ 
				freeCounter = 0;
				framesCounter += Time.deltaTime/4;
				if(framesCounter >= 1.0f)
				{
					framesCounter = 0.0f;
					hurt = true;
				}

			}

			if (Input.GetKeyDown (KeyCode.I))
			{
				player.gameObject.GetComponent<NewPlayerMovement>().valorCambio = 23;
				freeCounter += counterSpeed;
			}

			//Debug.Log(valorCambio);

			if(freeCounter >= freePlayer)
			{ 
				modifyPlayer = false;
				valorCambio = 0;
				anim.SetInteger("Detect", valorCambio);
				audio.PlayOneShot(cepo,1);

			}


		}

		/*if (EnemyAI.enemyHurt == true)
		{
			valorCambio = 1;
			anim.SetInteger("Detect", valorCambio);
			audio.PlayOneShot(cepo,1);
		}*/
			
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			//Debug.Log("enteredcepo");
			if(hurt)
			{
				valorCambio = 1;
				anim.SetInteger("Detect", valorCambio);
				if(!modifyPlayer)audio.PlayOneShot(cepo,1);
				audio.PlayOneShot(hurtSound,1);
				NewPlayerMovement.life -= 100;
				modifyPlayer = true;
				hurtFeedback.GetComponent<HurtFeedback>().framesCounter = 1.0f;
				hurt = false;
				Instantiate(bloodPs, new Vector3 (transform.position.x, 
				                                  transform.position.y + 1.2f
				                                  , -1), Quaternion.Euler(0, 0, 0));
				player.gameObject.GetComponent<NewPlayerMovement>().valorCambio = 23;
			}

		}
	}
}
