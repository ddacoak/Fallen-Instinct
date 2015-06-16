using UnityEngine;
using System.Collections;

public class candilSounds : MonoBehaviour {

	public AudioClip lightsOff;
	public AudioClip cristalBroken;

	AudioSource ownAudio;

	public bool play = false;
	public bool playLights = true;


	void Start () {

		ownAudio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (play) 
		{

			ownAudio.PlayOneShot(cristalBroken,1);
			play = false;
		}
		if (PlayerLightController.gotIt == true && playLights) {
			ownAudio.PlayOneShot (lightsOff, 1);
			playLights = false;
		}
	
	}
}
