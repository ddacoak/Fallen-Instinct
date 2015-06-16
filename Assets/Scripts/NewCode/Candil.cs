using UnityEngine;
using System.Collections;

public class Candil : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject playerLight;
	public GameObject text;
	public static bool candil = false;

	public static int fullCharge = 5000;
	public static int oilCounter = fullCharge;
	
	public AudioSource lightsFlickering;


	void Start () 
	{

	}

	void Update () 
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);

		if (viewDistance <= range) 
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				candil = true;
				text.SetActive(true);
				this.gameObject.SetActive(false);
				lightsFlickering.GetComponent<AudioSource>().volume = 0;
			}
		}

		if (PlayerLightController.enabled == true)
			oilCounter--;
	}
}