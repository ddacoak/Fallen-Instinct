using UnityEngine;
using System.Collections;

public class BreakGlass : MonoBehaviour 
{
	public static bool runBitch = false;
	public GameObject GlassPSLeft;
	public GameObject GlassPSRight;

	void Start () 
	{
		GlassPSLeft.SetActive (false);
		GlassPSRight.SetActive (false);
	}

	void Update () 
	{
		if (PlayerLightController.gotIt == true) 
		{
			GlassPSLeft.SetActive (true);
			GlassPSRight.SetActive (true);

			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			runBitch = true;
		}
	}
}
