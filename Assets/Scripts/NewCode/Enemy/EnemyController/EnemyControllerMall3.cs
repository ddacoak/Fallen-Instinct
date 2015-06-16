using UnityEngine;
using System.Collections;

public class EnemyControllerMall3 : MonoBehaviour 
{
	public GameObject leftGlass;
	public GameObject rightGlass;
	public GameObject extraRoom;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;
	public GameObject light5;

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
		if (BreakGlass.lightsOff) 
		{
			light1.SetActive (false);
			light2.SetActive (false);
			light3.SetActive (false);
			light4.SetActive (false);
			light5.SetActive (false);
		}
	}
}
