using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HurtFeedback : MonoBehaviour {

	public float framesCounter;
	private Color color;

	// Use this for initialization
	void Start () {
		color = GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (framesCounter);

		if (framesCounter > 0.0f)
			framesCounter -= Time.deltaTime /4;
		else if (framesCounter <= 0)
			framesCounter = 0.0f;

		color.a = framesCounter;

		GetComponent<Image>().color = color;



	}
}
