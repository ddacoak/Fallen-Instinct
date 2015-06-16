using UnityEngine;
using System.Collections;

public class SoundControllers : MonoBehaviour {

	public bool active = false;
	AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if(sound.volume < 1) sound.volume += Time.deltaTime/2;
			else sound.volume = 1;
		}
		if (!active) {
			if(sound.volume > 0) sound.volume -= Time.deltaTime;
			else sound.volume = 0;
		}
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			active = true;
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			active = false;
	}
}
