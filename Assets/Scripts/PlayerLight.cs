using UnityEngine;
using System;
using System.Collections;

public class PlayerLight : MonoBehaviour 
{
	private Vector2 center;
	private float radius;
	public float internalRadius;

	float colorAlpha;
	

	// Use this for initialization
	void Start () 
	{
		colorAlpha = 1;

		center = new Vector2(transform.position.x, transform.position.y);
		radius = transform.GetComponent<CircleCollider2D> ().radius;
	}
	

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{

			colorAlpha = (Vector2.Distance(other.transform.position,center) - internalRadius) / (radius - internalRadius) - 0.15f * Time.deltaTime;

			// Clamp alpha values
			if (colorAlpha > 1) colorAlpha = 1;
			else if (colorAlpha < 0.05f) colorAlpha = 0.05f;

			other.transform.FindChild("PlayerLight").GetComponent<PlayerLightController>().objectiveAlpha = colorAlpha * 5f;
			other.transform.FindChild("PlayerLight").GetComponent<PlayerLightController>().inLight = true;

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			other.transform.FindChild("PlayerLight").GetComponent<PlayerLightController>().objectiveAlpha = 5f;
			other.transform.FindChild("PlayerLight").GetComponent<PlayerLightController>().inLight = false;

		}
	}
}
