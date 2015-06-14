using UnityEngine;
using System.Collections;

public class EnemyControllerMall3 : MonoBehaviour 
{
	public GameObject leftGlass;
	public GameObject rightGlass;
	public GameObject extraRoom;

	void Start () 
	{
		leftGlass.SetActive (false);
		rightGlass.SetActive (false);
		extraRoom.SetActive (false);
	}

	void Update () 
	{
		if (BreakGlass.runBitch == true)
		{
			leftGlass.SetActive (true);
			rightGlass.SetActive (true);
			extraRoom.SetActive (true);
		}
	}
}
