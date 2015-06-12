using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public AudioClip attack;
	AudioSource audio;

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
		anim.SetInteger("Romper", valorCambio);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			Debug.Log ("canvia");
			NewPlayerMovement.missedAttack = false;
			audio.PlayOneShot(attack, 1);
			valorCambio = 1;
			//Destroy(this.gameObject);
		}else
			NewPlayerMovement.missedAttack = true;
	}
}
