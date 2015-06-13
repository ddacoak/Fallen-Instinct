using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour 
{
	public AudioClip playerHurt;
	public AudioClip zombiAttack;
	AudioSource audio;

	private int damage = 100;
	public GameObject player;
	public GameObject hurtFeedback;
	private float imageAlpha;
	public GameObject bloodPS;

	//ATTACK
	//-------------
	public GameObject attackObject;
	private GameObject playerLife;
	private float attackCounter = 0;
	public static bool hurt = false;
	public static bool hurt2 = false;


	//-------------
	
	void Start () 
	{
		audio = GetComponent<AudioSource>();
		imageAlpha = hurtFeedback.GetComponent<HurtFeedback> ().framesCounter;

	}

	void Update () 
	{
		//ATTACK
		//-------------

		//-------------
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			attackCounter += Time.deltaTime;
			if (attackCounter >= 1.0f)
			{
				Instantiate(bloodPS, player.transform.position, transform.rotation);
				NewPlayerMovement.life -= damage;
				hurt = true;
				hurt2 = true;
				hurtFeedback.GetComponent<HurtFeedback>().framesCounter = 1.0f;
				audio.PlayOneShot(playerHurt, 1f);
				audio.PlayOneShot(zombiAttack, 1f);
				attackCounter = 0;
			}
		}
	}	
}
