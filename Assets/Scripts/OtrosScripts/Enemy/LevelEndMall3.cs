﻿using UnityEngine;
using System.Collections;

public class LevelEndMall3 : MonoBehaviour {

	private float range = 1f;
	public GameObject player;

	public static bool youAreTheLight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float viewDistance = Vector3.Distance(player.transform.position, transform.position);
		
		if(viewDistance <= range)
		{
			youAreTheLight = true;
			Application.LoadLevel("Mall 4");
		}
	
	}
}
