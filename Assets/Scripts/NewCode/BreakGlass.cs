using UnityEngine;
using System.Collections;

public class BreakGlass : MonoBehaviour 
{
	public static bool runBitch = false;
	public static bool lightsOff = false;
	public GameObject GlassPSLeft;
	public GameObject GlassPSRight;
	public GameObject candilSounds;

	void Start () 
	{
		GlassPSLeft.SetActive (false);
		GlassPSRight.SetActive (false);
	}

	void Update () 
	{
		if (PlayerLightController.gotIt == true && Input.GetKeyDown(KeyCode.L)) 
		{
			GlassPSLeft.SetActive (true);
			GlassPSRight.SetActive (true);

			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			runBitch = true;
			candilSounds.GetComponent<candilSounds>().play = true;
		}
		if (PlayerLightController.gotIt == true)
			lightsOff = true;
	}
}
