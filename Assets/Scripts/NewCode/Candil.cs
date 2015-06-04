using UnityEngine;
using System.Collections;

public class Candil : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject text;
	public static bool candil = false;
	
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
				candil = true;
				text.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
}