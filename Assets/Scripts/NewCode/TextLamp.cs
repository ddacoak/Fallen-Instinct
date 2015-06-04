using UnityEngine;
using System.Collections;

public class TextLamp : MonoBehaviour 
{
	private float lifeCounter = 0;
	
	void Update () 
	{
		lifeCounter++;

		if (lifeCounter >= 300)
			this.gameObject.SetActive (false);
	}
}
