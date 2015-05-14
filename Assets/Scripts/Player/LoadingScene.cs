using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour 
{
	Animator anim;
	private int valorCambio;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		valorCambio = 4;
		anim.SetInteger("Transition", valorCambio);
	}
}
