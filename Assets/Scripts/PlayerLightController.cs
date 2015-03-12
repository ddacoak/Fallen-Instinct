using UnityEngine;
using System.Collections;

public class PlayerLightController : MonoBehaviour {
	
	private bool enabled;
	private bool turningOn;
	
	public Color colorAlpha;

	public float alphaBase;
	public float alphaExternalController;

	public int time;
	
	// Use this for initialization
	void Start () 
	{
		enabled = false;
		turningOn = false;

		colorAlpha = transform.FindChild("playerLight1").renderer.material.GetColor("_Color");

		alphaBase = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Light disabled
		if (enabled == false) 
		{

			// Enable light
			if (Input.GetKeyDown (KeyCode.L)) 
			{
				enabled = true;
				turningOn = true;
			}

			// Turn lights off
			if (alphaBase > 0)
				alphaBase -= 0.1f;
			else
				alphaBase = 0f;

		}
		// Light enabled
		else 
		{
			// Disable light
			if (Input.GetKeyDown (KeyCode.L)) {
				enabled = false;
				turningOn = false;
			}
			// Light alpha lerp (increment alpha slowly)
			if (turningOn)
			{
				//while(colorAlpha.a < 1.0f) colorAlpha.a += 0.05f;
				if (alphaBase < alphaExternalController) 
					alphaBase += 0.05f;
				else
				{
					alphaBase = alphaExternalController;
					turningOn = false;
				}
			}
		}

		// Controls the maximum amount of alpha
		if (enabled && !turningOn) 
			alphaBase = Mathf.Lerp(alphaBase, alphaExternalController, 0.2f);
			


		float childCounter = 0;
		foreach (Transform child in transform) 
		{
			colorAlpha.a = Mathf.Lerp(colorAlpha.a, alphaBase, 0.75f);

			if (enabled && !turningOn) 
			{
				if (Random.Range (1, time) == 1)
				{
					child.renderer.material.SetColor ("_Color", new Color (colorAlpha.r, colorAlpha.g, colorAlpha.b,
					                                                       Random.Range ((0.5f + childCounter) * colorAlpha.a, colorAlpha.a)));
				} 
			}
			else
				child.renderer.material.SetColor ("_Color", colorAlpha);

			childCounter += 0.1f;
		}

		//Debug.Log (colorAlpha.a);

	}
}

