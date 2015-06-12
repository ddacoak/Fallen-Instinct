using UnityEngine;
using System.Collections;

public class LookOtherWay : MonoBehaviour 
{
	public GameObject player;
	public GameObject otherWayText;

	private bool otherWayBoolean = false;

	void Update () 
	{
		if(player.transform.position.x >= 42 && otherWayBoolean == false)
		{
			otherWayText.SetActive(true);
			otherWayBoolean = true;
		}

		if(player.transform.position.x >= 49)
		{
			NewPlayerMovement.life = 0;
		}
	}
}
