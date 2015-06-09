using UnityEngine;
using System.Collections;

public class LightIntensityAlpha : MonoBehaviour {

	private GameObject light;
	private int max;

	// Use this for initialization
	void Start () {

		light = this.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Random.Range(0,10) == 1)max = Random.Range (0, 2);
		light.GetComponent<Light> ().intensity = Mathf.Lerp (0, max, 60f);
	
	}
}
