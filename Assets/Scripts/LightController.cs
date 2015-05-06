using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	private bool enabled;
	private bool turningOn;


	Color colorAlpha;
	public int time;
	public float rand1;
	public float rand2;

	// Use this for initialization
	void Start () {
	
		enabled = false;
		turningOn = false;
	}
	
	// Update is called once per frame
	void Update () {

		colorAlpha = renderer.material.GetColor("_Color");


		if (enabled == false) {

			if (Input.GetKeyDown (KeyCode.L)) {
				enabled = true;
				turningOn = true;
			}

			if(colorAlpha.a > 0) colorAlpha.a -= 0.1f;
			else colorAlpha.a = 0f;


		}

		else{

			if (Input.GetKeyDown (KeyCode.L)) {
				enabled = false;
				turningOn = false;
			}
			
			if(turningOn) {
				//while(colorAlpha.a < 1.0f) colorAlpha.a += 0.05f;
				if(colorAlpha.a < 1.0f) 
					colorAlpha.a += 0.05f;

				else turningOn = false;
			}

			else{				
				if(Random.Range(1,time) == 1)					
					colorAlpha.a = Random.Range(rand1, rand2);
				
								
			}

		}

		//if(enabled) Debug.Log ("enabled");
		//else Debug.Log ("disabled");

		renderer.material.SetColor("_Color", colorAlpha);

	}
}
