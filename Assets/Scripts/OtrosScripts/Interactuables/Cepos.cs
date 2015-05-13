using UnityEngine;
using System.Collections;

public class Cepos : MonoBehaviour 
{
	Animator anim;
	private int valorCambio = 0;

	public GameObject player;
	public float range = 0.5f;

	//Damage
	public int power = 100;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);

		if (viewDistance <= range) 
		{
			valorCambio = 1;
			anim.SetInteger("Detect", valorCambio);
		}
	}
}
