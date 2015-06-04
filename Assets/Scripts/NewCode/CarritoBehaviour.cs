using UnityEngine;
using System.Collections;

public class CarritoBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  transform.position.y / 100.0f - 0.995f);
	
	}
}
