using UnityEngine;
using System.Collections;

public class AvoidEnemy : MonoBehaviour 
{
	private bool zombiKilled = false;

	public GameObject zombi8;
	public GameObject avoidEnemeyText;

	void Update () 
	{
		if (zombi8 == null && zombiKilled == false) 
		{
			avoidEnemeyText.SetActive (true);
			zombiKilled = true;
		}
	}
}
