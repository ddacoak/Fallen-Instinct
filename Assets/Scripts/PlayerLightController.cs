using UnityEngine;
using System.Collections;

public class PlayerLightController : MonoBehaviour {
	
	private bool enabled = true;
	public bool inLight = false;

	public float objectiveAlpha;
	private float randomAlpha;

	public float lightOscilation = 5;
	public float lightFadeSpeed = 0.04f;

	public float minimumLight = 0.5f;

	[HideInInspector] public Light light;
	
	// Use this for initialization
	void Start () 
	{
		light = transform.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.L))
			enabled = !enabled;
		if (!inLight) {
			if(enabled)
				objectiveAlpha = 5f;
		}

		if (!enabled)
			objectiveAlpha = 0;


		randomAlpha = Random.Range (objectiveAlpha * (100 - lightOscilation) /100, objectiveAlpha * (100 + lightOscilation) /100);
		if(enabled) if (randomAlpha < minimumLight) randomAlpha = minimumLight;
		light.intensity = Mathf.Lerp (light.intensity, randomAlpha, lightFadeSpeed);

	}
}

