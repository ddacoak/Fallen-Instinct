using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject text;
	public static bool candil = false;

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
				candil = true;
				text.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
}
