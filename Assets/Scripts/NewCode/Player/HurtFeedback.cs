using UnityEngine;
using System.Collections;

public class HurtFeedback : MonoBehaviour 
{
	private float lifeCounter = 0;
	
	void Update () 
	{
		lifeCounter++;

		/*if (lifeCounter >= 50)
			GetComponent<MeshRenderer> ().material.color = new Color(1, 1, 1, 0.5f);
		
		if (lifeCounter >= 100)
			GetComponent<MeshRenderer> ().material.color = new Color(1, 1, 1, 0.25f);*/
		
		if (lifeCounter >= 50)
			this.gameObject.SetActive (false);
	}
}
