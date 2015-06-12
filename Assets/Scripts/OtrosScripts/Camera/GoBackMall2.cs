using UnityEngine;
using System.Collections;

public class GoBackMall2 : MonoBehaviour 
{
	void Update () 
	{
		if (NewPlayerMovement.dead == true) 
		{
			Application.LoadLevel ("Mall 2");
			NewPlayerMovement.dead = false;
			NewPlayerMovement.life = NewPlayerMovement.maxLife;
		}
	}
}
