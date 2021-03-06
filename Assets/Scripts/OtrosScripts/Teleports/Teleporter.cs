﻿using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
	public GameObject player;
	public GameObject locator;
	private bool teleporting = false;
	public GameObject blackPlane;

	private float framesCounter = 0;

	private bool fadeIn = false;

	public GameObject puerta;

	void OnTriggerEnter2D(Collider2D other)
	{
		framesCounter = 0;

		if (other.name == "Player")
		{
			if (blackPlane.GetComponent<MeshRenderer>().enabled == false) blackPlane.GetComponent<MeshRenderer>().enabled = true;
			teleporting = true;
			fadeIn = true;
			blackPlane = other.GetComponent<NewPlayerMovement>().blackPlane;
		}
	}

	void Update()
	{
		if (fadeIn) {	
			if (teleporting) {
				
				framesCounter += Time.deltaTime * 2;
				
				blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, framesCounter);


				
				if (blackPlane.GetComponent<Renderer> ().material.color.a >= 1) {  
					framesCounter = 4f;
					blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 1);
					player.transform.position = locator.transform.position;
					teleporting = false;
				}
			}
			
			if (!teleporting) {
				framesCounter -= Time.deltaTime * 2;
				blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, framesCounter);
			}

			if (blackPlane.GetComponent<Renderer> ().material.color.a > 0.8f) {
				puerta.GetComponent<GateBehaviour>().gate.transform.localPosition = new Vector3 (puerta.GetComponent<GateBehaviour>().gate.transform.localPosition.x, 
				                                                                                 puerta.GetComponent<GateBehaviour>().max,
				                                                                                 puerta.GetComponent<GateBehaviour>().gate.transform.localPosition.z);
				puerta.GetComponent<GateBehaviour>().open = false;
			}

			if (blackPlane.GetComponent<Renderer> ().material.color.a <= 0) {
				blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 0);
				fadeIn = false;
				blackPlane.GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}
}
