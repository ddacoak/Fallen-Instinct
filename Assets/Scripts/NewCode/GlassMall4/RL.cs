using UnityEngine;
using System.Collections;

public class RL : MonoBehaviour 
{
	public GameObject player;

	public GameObject glassPS;

	private bool doIt = false;

	public AudioClip sound;
	AudioSource audio;

	void Start () 
	{
		glassPS.SetActive (false);
		audio = GetComponent<AudioSource> ();//83.7
	}

	void Update () 
	{
		if(player.transform.position.x >= 74.6f && doIt == false)
		{
			Debug.Log (3);
			glassPS.SetActive (true);
			audio.PlayOneShot(sound,1);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			doIt = true;
		}
	}
}
