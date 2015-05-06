using UnityEngine;
using System.Collections;


public class Alpha : MonoBehaviour {

	Color colorAlpha;

	 

	// Use this for initialization
	void Start () {
	
		colorAlpha = transform.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (colorAlpha.a > 0)
			colorAlpha.a -= Time.deltaTime / 5;

		transform.GetComponent<Renderer>().material.color = colorAlpha;
	}
}
