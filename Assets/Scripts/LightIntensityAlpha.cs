using UnityEngine;
using System.Collections;

public class LightIntensityAlpha : MonoBehaviour {

	private GameObject light;
	private float intensity;
	private float max;
	public float min;

	// Use this for initialization
	void Start () {

		light = this.gameObject;
		intensity = light.GetComponent<Light> ().intensity;
	}
	
	// Update is called once per frame
	void Update () {

		if(Random.Range(0,5) == 1)max = Random.Range (min, intensity);
		light.GetComponent<Light> ().intensity = Mathf.Lerp (0, max, 60f);
	
	}
}
