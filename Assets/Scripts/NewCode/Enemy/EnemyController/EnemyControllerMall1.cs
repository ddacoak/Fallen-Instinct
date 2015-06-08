using UnityEngine;
using System.Collections;

public class EnemyControllerMall1 : MonoBehaviour 
{
	public GameObject player;

	public GameObject secondArea;
	public GameObject thirdArea;

	private float secondAreaTrigger  = 4.0f;
	private float thirdAreaTrigger  = -2.0f;

	void Start () 
	{
		secondArea.SetActive (false);
		thirdArea.SetActive (false);
	}

	void Update () 
	{
		if (player.transform.position.y <= secondAreaTrigger)
			secondArea.SetActive (true);

		if (player.transform.position.y <= thirdAreaTrigger)
			thirdArea.SetActive (true);
	}
}
