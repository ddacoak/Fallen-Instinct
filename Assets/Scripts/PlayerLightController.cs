using UnityEngine;
using System.Collections;

public class PlayerLightController : MonoBehaviour {
	
	public static bool enabled = false;
	public bool inLight = false;

	public float objectiveAlpha;
	private float randomAlpha;

	public float lightOscilation = 5;
	public float lightFadeSpeed = 0.04f;

	public float minimumLight = 0.5f;

	[HideInInspector] public Light light;

	public static bool gotIt = false;
	
	// Use this for initialization
	void Start () 
	{
		light = transform.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (Candil.candil);
		if (Candil.candil == true) 
		{
			gotIt = true;

			if (Input.GetKeyUp (KeyCode.L))
				enabled = !enabled;
			if (!inLight) {
				if(enabled)
					objectiveAlpha = 4.3f;
			}
			
			if (!enabled)
				objectiveAlpha = 0;
			
			
			randomAlpha = Random.Range (objectiveAlpha * (100 - lightOscilation) /100, objectiveAlpha * (100 + lightOscilation) /100);
			if(enabled) if (randomAlpha < minimumLight) randomAlpha = minimumLight;
			light.intensity = Mathf.Lerp (light.intensity, randomAlpha, lightFadeSpeed);

			if (enabled == true)
				Candil.oilCounter--;

			/*if (Candil.oilCounter <= 0) 
			{
				Candil.oilCounter = Candil.fullCharge;
				enabled = false;
				Candil.candil = false;
			}*/
		}
	}
}

