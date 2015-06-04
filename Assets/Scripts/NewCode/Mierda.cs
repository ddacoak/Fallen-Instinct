using UnityEngine;
using System.Collections;

public class Mierda : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject gold;
	public GameObject scarPileRemoved;

	void Start () 
	{
		
	}

	void Update () 
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);
		
		if (viewDistance <= range) 
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				Instantiate(gold, this.gameObject.transform.position,transform.rotation);
				Instantiate(scarPileRemoved, this.gameObject.transform.position,transform.rotation);
				Destroy(this.gameObject);
			}
		}
	}
}
