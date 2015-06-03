using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
	private int attackDuration = 0;

	void Update () 
	{
		attackDuration++;

		if (attackDuration >= 10)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Zombi") 
		{
			Destroy(this.gameObject);
		}
	}	
}
