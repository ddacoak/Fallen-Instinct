using UnityEngine;
using System.Collections;

public class TeleportRoom2 : MonoBehaviour 
{
	public GameObject player;
	private bool teleporting = false;
	public GameObject blackPlane;
	
	private float framesCounter = 0;
	
	private bool fadeIn = false;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		framesCounter = 0;
		
		if (other.name == "Player")
		{
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
					player.transform.position = new Vector3(0.03f, 3f, -0.4f);
					teleporting = false;
				}
			}
			
			if (!teleporting) {
				framesCounter -= Time.deltaTime * 2;
				blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, framesCounter);
			}
			
			if (blackPlane.GetComponent<Renderer> ().material.color.a <= 0) {
				blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 0);
				fadeIn = false;
			}
		}
	}
}
