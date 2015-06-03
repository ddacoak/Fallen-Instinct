using UnityEngine;
using System.Collections;

public class HierbaMedicinal : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) 
		{
			NewPlayerMovement.life += 100;
			Destroy(this.gameObject);
		}
	}
}
