using UnityEngine;
using System.Collections;

public class GoBackMall4 : MonoBehaviour 
{
	void Update () 
	{
		if (NewPlayerMovement.dead == true) 
		{
			Application.LoadLevel ("Mall 4");
			NewPlayerMovement.dead = false;
			NewPlayerMovement.life = NewPlayerMovement.maxLife;
			Candil.oilCounter = Candil.fullCharge;
			PlayerLightController.enabled = false;
		}
	}
}
