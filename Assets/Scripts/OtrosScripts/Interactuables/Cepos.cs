using UnityEngine;
using System.Collections;

public class Cepos : MonoBehaviour 
{
	Animator anim;
	private int valorCambio = 0;

	public GameObject playerShadow;
	public float range = 0.5f;

	public GameObject player;

	public AudioClip cepo;
	AudioSource audio;
	private bool playAudio = true;

	//Damage
	public int power = 100;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
	}

	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("enteredcepo");

			valorCambio = 1;
			anim.SetInteger("Detect", valorCambio);

			if(playAudio)
			{
				audio.PlayOneShot(cepo,1);
				playAudio = false;
			}

		}
	}

		
}
