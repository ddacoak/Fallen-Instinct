using UnityEngine;
using System.Collections;

public class LR : MonoBehaviour 
{
	public GameObject player;

	public GameObject glassPS;

	private bool doIt = false;

	public AudioClip sound;
	AudioSource audio;

	void Start () 
	{
		glassPS.SetActive (false);
		audio = GetComponent<AudioSource> ();//74.6f
	}

	void Update () 
	{
		if(player.transform.position.x >= 83.7f && doIt == false)
		{
			Debug.Log (2);
			glassPS.SetActive (true);
			audio.PlayOneShot(sound,1);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			doIt = true;
		}
	}
}
