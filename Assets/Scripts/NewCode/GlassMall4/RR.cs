using UnityEngine;
using System.Collections;

public class RR : MonoBehaviour 
{
	public GameObject player;

	public GameObject glassPS;

	private bool doIt = false;

	void Start () 
	{
		glassPS.SetActive (false);
	}

	void Update () 
	{
		if(player.transform.position.x >= 94f && doIt == false)
		{
			glassPS.SetActive (true);
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			doIt = true;
		}
	}
}
