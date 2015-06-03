using UnityEngine;
using System.Collections;

public class Cofre : MonoBehaviour 
{
	Animator anim;
	private int valorCambio;

	public GameObject interactuable;
	
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("no me toques, no tienes ningun derecho a tocarme");
		if (other.tag == "Player") 
		{
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				Instantiate (interactuable);

				valorCambio = 11;
				anim.SetInteger ("Cofre", valorCambio);
			}
		}
	}
}