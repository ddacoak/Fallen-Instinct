using UnityEngine;
using System.Collections;

public class GoBackMall3 : MonoBehaviour 
{
	void Update () 
	{
		if (NewPlayerMovement.dead == true) 
		{
			Application.LoadLevel ("Mall 3");
			NewPlayerMovement.dead = false;
			NewPlayerMovement.life = NewPlayerMovement.maxLife;
		}
	}
}
