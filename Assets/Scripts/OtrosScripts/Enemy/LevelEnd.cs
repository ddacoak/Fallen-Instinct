using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	private float range = 2f;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float viewDistance = Vector3.Distance(player.transform.position, transform.position);
		
		if(viewDistance <= range)
		{
			Application.LoadLevel("Mall 2");
		}
	
	}
}
