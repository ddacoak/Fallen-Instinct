﻿using UnityEngine;
using System.Collections;

public class LR : MonoBehaviour 
{
	public GameObject player;

	public GameObject glassPS;

	private bool doIt = false;

	void Start () 
	{
		glassPS.SetActive (false);
	}

	void Update () 
	{
		if(player.transform.position.x >= 74.6f && doIt == false)
		{
			glassPS.SetActive (true);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			doIt = true;
		}
	}
}
