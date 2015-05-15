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

	//Damage
	public int power = 100;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
	}

	void Update () 
	{
		float viewDistance = Vector3.Distance(playerShadow.transform.position, transform.position);

		if (viewDistance <= range) 
		{
			valorCambio = 1;
			anim.SetInteger("Detect", valorCambio);
			audio.PlayOneShot(cepo, 1);
		}

		/*if (valorCambio == 1)
		{

		}*/
	}

		
}
