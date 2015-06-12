using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public AudioClip attack;
	AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerAttack") 
		{
			audio.PlayOneShot(attack, 1);
			Destroy(this.gameObject);
		}
	}
}
