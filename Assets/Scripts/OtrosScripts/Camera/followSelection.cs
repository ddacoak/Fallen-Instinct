using UnityEngine;
using System.Collections;

public class followSelection : MonoBehaviour {

	// Use this for initialization

	private GameObject follower;
	public GameObject selection;
	private float x;
	private float y;

	void Start(){
		follower = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		x = selection.transform.position.x;
		y = selection.transform.position.y;

		follower.transform.position = new Vector3 (x, y, -0.5f);
	
	}
}
