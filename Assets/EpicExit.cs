using UnityEngine;
using System.Collections;

public class EpicExit : MonoBehaviour {

	public GameObject glassPs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			Instantiate(glassPs, new Vector3 (other.transform.position.x, 
			                                  other.transform.position.y + 1.2f
			                                  , -1), Quaternion.Euler(0, 0, 0));
	}
}
