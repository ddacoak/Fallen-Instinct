using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{
	public AudioClip attack;
	AudioSource audio;

	private bool breakBoolean = false;

	Animator anim;
	public int valorCambio = 0;

	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			if (breakBoolean == false)
				audio.PlayOneShot(attack, 1);
			
			NewPlayerMovement.missedAttack = false;
			valorCambio = 1;
			anim.SetInteger("Romper", valorCambio);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			breakBoolean = true;
		}else
			NewPlayerMovement.missedAttack = true;
	}
}
