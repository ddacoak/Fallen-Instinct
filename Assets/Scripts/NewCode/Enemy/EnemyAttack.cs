using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public AudioClip playerHurt;
	AudioSource audio;

	//ATTACK
	//-------------
	public GameObject attackObject;
	private GameObject playerLife;
	private int attackCounter = 0;
	public static bool hurt = false;
	private float rangeAttack = 10.0f;
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
				NewPlayerMovement.life -= 100;
				hurt = true;
				audio.PlayOneShot(playerHurt, 1F);
			}
		}
	}	
}
