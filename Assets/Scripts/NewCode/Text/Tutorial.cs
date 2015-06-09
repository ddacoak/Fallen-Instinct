using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public GameObject player;
	public GameObject movementTutorial;
	public GameObject runTutorial;
	public GameObject attackTutorial;
	public GameObject interactTutorial;

	private bool runTextBoolean = false;
	private bool attackTextBoolean = false;
	private bool interactTextBoolean = false;

	void Start () 
	{
		movementTutorial.SetActive (true);
	}

	void Update () 
	{
		if (player.transform.position.x >= -6.5f && runTextBoolean == false) 
		{
			runTutorial.SetActive(true);
			runTextBoolean = true;
		}


		if (player.transform.position.x >= -5.0f && attackTextBoolean == false) 
		{
			attackTutorial.SetActive(true);
			attackTextBoolean = true;
		}

		if (player.transform.position.x >= -1.5f && interactTextBoolean == false) 
		{
			interactTutorial.SetActive(true);
			interactTextBoolean = true;
		}
	}
}
