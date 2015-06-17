using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour 
{
	AudioSource audio;

	void Start () 
	{
		audio = GetComponent<AudioSource>();
		audio.Play ();
	}

	void Update () 
	{
		
	}
}
