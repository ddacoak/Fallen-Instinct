using UnityEngine;
using System.Collections;

public class GUIOil : MonoBehaviour 
{
	private bool firstChange = false;
	private bool secondChange = false;
	private bool thirdChange = false;
	private bool fourthChange = false;
	private bool fifthChange = false;

	void Update () 
	{
		//if (Candil.oilCounter >= 4001 && Candil.oilCounter <= 5000)
			//transform.position = new Vector3(transform.position.x, 3.873f, 0);

		if (Candil.oilCounter >= 3001 && Candil.oilCounter <= 4000) 
		{
			if (firstChange == false) 
			{
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				firstChange = true;
			}
		}

		if (Candil.oilCounter >= 2001 && Candil.oilCounter <= 3000) 
		{
			if (secondChange == false) 
			{
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				secondChange = true;
			}
		}

		if (Candil.oilCounter >= 1001 && Candil.oilCounter <= 2000) 
		{
			if (thirdChange == false) 
			{
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				thirdChange = true;
			}
		}

		if (Candil.oilCounter >= 1 && Candil.oilCounter <= 1000) 
		{
			if (fourthChange == false) 
			{
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				fourthChange = true;
			}
		}

		if (Candil.oilCounter >= 0 && Candil.oilCounter <= 1) 
		{
			if (fifthChange == false) 
			{
				transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				fifthChange = true;
				NewPlayerMovement.life= 0;
			}
		}
	}
}
