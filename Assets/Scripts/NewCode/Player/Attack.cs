using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
	public AudioClip attack;
	AudioSource audio;

	private int attackDuration = 0;

	void Start () 
	{
		audio = GetComponent<AudioSource>();
	}

	void Update () 
	{
		attackDuration++;

		if (attackDuration >= 10)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Zombi") {
			NewPlayerMovement.missedAttack = false;
			Destroy (this.gameObject);
		} else
			NewPlayerMovement.missedAttack = true;
	}	
}
