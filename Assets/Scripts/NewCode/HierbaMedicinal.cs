using UnityEngine;
using System.Collections;

public class HierbaMedicinal : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject curePS;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);

		if (viewDistance <= range) 
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				NewPlayerMovement.life += 100;
				Destroy(this.gameObject);
				Instantiate(curePS, player.transform.position, transform.rotation);
			}
		}
	}
}
