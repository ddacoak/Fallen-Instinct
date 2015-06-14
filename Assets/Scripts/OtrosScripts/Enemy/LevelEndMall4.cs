using UnityEngine;
using System.Collections;

public class LevelEndMall4 : MonoBehaviour 
{
	private float range = 1f;
	public GameObject player;

	void Update () {

		float viewDistance = Vector3.Distance(player.transform.position, transform.position);

		if(viewDistance <= range)
		{
			Application.LoadLevel("Menu");
		}

	}
}
