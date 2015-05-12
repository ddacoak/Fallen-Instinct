using UnityEngine;
using System.Collections;

public class FootprintsLife : MonoBehaviour 
{
	private float lifeCounter = 0;
	
	void Start () 
	{

	}

	void Update () 
	{
		lifeCounter++;

		if (lifeCounter >= 400)
		{
			DestroyObject(this.gameObject);
		}
	}
}
