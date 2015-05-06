using UnityEngine;
using System.Collections;

public class alphaRandom : MonoBehaviour {

	Color colorAlpha;
	public int time;
	public float rand1;
	public float rand2;

	
	
	// Use this for initialization
	void Start () {
		
		colorAlpha = renderer.material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
	
		colorAlpha = renderer.material.GetColor("_Color");

		if(Random.Range(1,time) == 1)

			colorAlpha.a = Random.Range(rand1, rand2);
		
		renderer.material.SetColor("_Color", colorAlpha);
	}
}
