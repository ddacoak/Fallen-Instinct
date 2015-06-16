using UnityEngine;
using System.Collections;

public class LL : MonoBehaviour 
{
	public GameObject player;

	public GameObject glassPS;

	private bool doIt = false;

	public AudioClip sound;
	AudioSource audio;

	void Start () 
	{
		glassPS.SetActive (false);
		audio = GetComponent<AudioSource> ();//64.02f
	}

	void Update () 
	{
		if(player.transform.position.x >= 94f && doIt == false)
		{
			Debug.Log (1);
			glassPS.SetActive (true);
			audio.PlayOneShot(sound,1);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			doIt = true;
		}
	}
}
