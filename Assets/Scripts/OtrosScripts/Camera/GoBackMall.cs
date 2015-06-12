using UnityEngine;
using System.Collections;

public class GoBackMall : MonoBehaviour 
{
	void Update () 
    {
        if (NewPlayerMovement.dead == true) 
		{
			Application.LoadLevel ("Mall");
			NewPlayerMovement.dead = false;
			NewPlayerMovement.life = NewPlayerMovement.maxLife;
		}
	}
}
