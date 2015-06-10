using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public AudioClip playerHurt;
	AudioSource audio;

	private int damage = 100;
	public GameObject player;
	public GameObject hurtFeedback;
	public GameObject bloodPS;

	//ATTACK
	//-------------
	public GameObject attackObject;
	private GameObject playerLife;
	private int attackCounter = 0;
	public static bool hurt = false;
	//-------------
	
	void Start () 
	{
		audio = GetComponent<AudioSource>();
	}

	void Update () 
	{
		//ATTACK
		//-------------
		attackCounter++;
		
		if (attackCounter >= 30) 
		{
			attackCounter = 0;
		}
		//-------------
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (attackCounter == 15)
			{
				hurtFeedback.SetActive(true);
				Instantiate(bloodPS, player.transform.position, transform.rotation);
				NewPlayerMovement.life -= damage;
				hurt = true;
				audio.PlayOneShot(playerHurt, 1F);
			}
		}
	}	
}
