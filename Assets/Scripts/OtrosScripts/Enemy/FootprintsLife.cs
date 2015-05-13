using UnityEngine;
using System.Collections;

public class FootprintsLife : MonoBehaviour 
{
	private float lifeCounter = 0;

	void Update () 
	{
		lifeCounter++;

		if (lifeCounter >= 200)
			GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 0.5f);

		if (lifeCounter >= 400)
			GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 0.25f);

		if (lifeCounter >= 500)
			DestroyObject(this.gameObject);
	}
}
