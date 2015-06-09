using UnityEngine;
using System.Collections;

public class EnemyControllerMall2 : MonoBehaviour 
{
	public GameObject player;
	
	public GameObject secondArea;
	public GameObject thirdArea;
	public GameObject fourthArea;
	public GameObject fifthArea;
	
	private float secondAreaTrigger  = 3.0f;
	private float thirdAreaTrigger  = 10.0f;
	private float fourthAreaTrigger  = 27.28f;
	private float fifthAreaTrigger  = 35f;
	
	void Start () 
	{
		secondArea.SetActive (false);
		thirdArea.SetActive (false);
		fourthArea.SetActive (false);
		fifthArea.SetActive (false);
	}
	
	void Update () 
	{
		if (player.transform.position.x >= secondAreaTrigger)
			secondArea.SetActive (true);
		
		if (player.transform.position.x >= thirdAreaTrigger)
			thirdArea.SetActive (true);

		if (player.transform.position.x >= fourthAreaTrigger)
			fourthArea.SetActive (true);

		if (player.transform.position.x >= fifthAreaTrigger)
			fifthArea.SetActive (true);
	}
}
