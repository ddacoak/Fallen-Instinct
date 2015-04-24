using UnityEngine;
using System.Collections;

public class alphaRandom : MonoBehaviour {

	Color colorAlpha;
	public int time;
	public float rand1;
	public float rand2;

	
	
	// Use this for initialization
	void Start () {
		
		colorAlpha = GetComponent<Renderer>().material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
	
		colorAlpha = GetComponent<Renderer>().material.GetColor("_Color");

		if(Random.Range(1,time) == 1)

			colorAlpha.a = Random.Range(rand1, rand2);
		
		GetComponent<Renderer>().material.SetColor("_Color", colorAlpha);
	}
}
