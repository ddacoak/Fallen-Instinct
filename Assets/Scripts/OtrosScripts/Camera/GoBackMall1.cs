using UnityEngine;
using System.Collections;

public class GoBackMall1 : MonoBehaviour 
{
	void Update () 
	{
		if (NewPlayerMovement.dead == true) 
		{
			Application.LoadLevel ("Mall 1");
			NewPlayerMovement.dead = false;
			NewPlayerMovement.life = NewPlayerMovement.maxLife;
		}
	}
}
