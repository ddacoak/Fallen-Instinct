using UnityEngine;
using System.Collections;

public class TextLife : MonoBehaviour 
{
	private int textCounter = 0;

	void Update () 
	{
		textCounter++;

		if (textCounter >= 200)
			this.gameObject.SetActive (false);
	}
}
