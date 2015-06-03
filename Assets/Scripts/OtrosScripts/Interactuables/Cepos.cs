using UnityEngine;
using System.Collections;

public class Cepos : MonoBehaviour 
{
	Animator anim;
	private int valorCambio = 0;

	public GameObject playerShadow;
	public float range = 0.5f;
	public GameObject player;

	public AudioClip cepo;
	public AudioClip hurtSound;
	AudioSource audio;

	private bool hurt = true;

	private bool modifyPlayer = false;
	public float speed;
	public GameObject bloodPs;

	private int freePlayer = 600;
	private int freeCounter = 0;
	private int counterLower = 5;
	private int counterSpeed = 100;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
	}

	void Update () 
	{
		if (modifyPlayer) {
			if(player.GetComponent<Transform>().position.x < transform.position.x) 
				player.GetComponent<Transform>().position = new Vector3 (player.GetComponent<Transform>().position.x + speed,
				                                                         player.GetComponent<Transform>().position.y,
				                                                         player.GetComponent<Transform>().position.z);
			if(player.GetComponent<Transform>().position.x > transform.position.x) 
				player.GetComponent<Transform>().position = new Vector3 (player.GetComponent<Transform>().position.x - speed,
				                                                         player.GetComponent<Transform>().position.y,
				                                                         player.GetComponent<Transform>().position.z);
			if(player.GetComponent<Transform>().position.y < transform.position.y + 1.2) 
				player.GetComponent<Transform>().position = new Vector3 (player.GetComponent<Transform>().position.x,
				                                                         player.GetComponent<Transform>().position.y + speed,
				                                                         player.GetComponent<Transform>().position.z);
			if(player.GetComponent<Transform>().position.y > transform.position.y + 1.2) 
				player.GetComponent<Transform>().position = new Vector3 (player.GetComponent<Transform>().position.x,
				                                                         player.GetComponent<Transform>().position.y - speed,
				                                                         player.GetComponent<Transform>().position.z);

			if((player.GetComponent<Transform>().position.x <= transform.position.x + 0.2 && player.GetComponent<Transform>().position.x >= transform.position.x - 0.2)
			   &&(player.GetComponent<Transform>().position.y <= (transform.position.y + 1.2) + 0.2 && player.GetComponent<Transform>().position.y >= (transform.position.y + 1.2) - 0.2)) 
			{
				player.GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y + 1.2f, player.GetComponent<Transform>().position.z);
			}

			if (freeCounter > 0) freeCounter -= counterLower;
			else freeCounter = 0;

			if (Input.GetKeyDown (KeyCode.I)) freeCounter += counterSpeed;

			Debug.Log(valorCambio);

			if(freeCounter >= freePlayer)
			{ 
				modifyPlayer = false;
				valorCambio = 0;
				anim.SetInteger("Detect", valorCambio);
				audio.PlayOneShot(cepo,1);

			}


		}
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("enteredcepo");
			if(hurt)
			{
				valorCambio = 1;
				anim.SetInteger("Detect", valorCambio);
				audio.PlayOneShot(cepo,1);
				audio.PlayOneShot(hurtSound,1);
				NewPlayerMovement.life -= 100;
				modifyPlayer = true;
				hurt = false;
				Instantiate(bloodPs, new Vector3 (transform.position.x, 
				                                  transform.position.y + 1.2f
				                                  , -1), Quaternion.Euler(0, 0, 0));
				Instantiate(bloodPs, new Vector3 (transform.position.x, 
				                                  transform.position.y + 1.2f
				                                  , -1), Quaternion.Euler(0, 0, 0));
			}

		}
	}

		
}
