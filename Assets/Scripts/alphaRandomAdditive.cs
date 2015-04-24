using UnityEngine;
using System.Collections;

public class alphaRandomAdditive : MonoBehaviour {

	Color colorAlpha;
	public int time;
	public float rand1;
	public float rand2;

	
	
	// Use this for initialization
	void Start () {
		
		colorAlpha = GetComponent<Renderer>().material.GetColor("_TintColor");
	}
	
	// Update is called once per frame
	void Update () {
	
		colorAlpha = GetComponent<Renderer>().material.GetColor("_TintColor");

		if(Random.Range(1,time) == 1)

			colorAlpha.a = Random.Range(rand1, rand2) * (Time.deltaTime * 100);
			//Debug.Log ("colorAlpha.a = " + Time.deltaTime.ToString());
		
		GetComponent<Renderer>().material.SetColor("_TintColor", colorAlpha);
	}
}
