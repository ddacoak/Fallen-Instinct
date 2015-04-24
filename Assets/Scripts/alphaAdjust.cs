using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class alphaAdjust : MonoBehaviour {
	
	Color colorAlpha;
	public float alpha;
	
	
	// Use this for initialization
	void Start () {
		colorAlpha = transform.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		colorAlpha.a = alpha;
		colorAlpha.r = 1;
		colorAlpha.g = 1;
		colorAlpha.b = 1;
		transform.GetComponent<SpriteRenderer> ().color = colorAlpha;
	}
}