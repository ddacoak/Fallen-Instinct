using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	public GameObject inventory;
	public GameObject selection;
	private bool active = false;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.J) && active == false) 
		{
			inventory.SetActive (true);
			selection.SetActive (true);
			active = true;
			Time.timeScale = 0;
			if(Input.GetKeyDown(KeyCode.D))
			{
				selection.transform.position += new Vector3(1.5f, 0, 0);
			}else if (Input.GetKeyDown(KeyCode.A))
				{
					selection.transform.position += new Vector3(-1.5f, 0, 0);
				}else if (Input.GetKeyDown(KeyCode.W))
					{
						selection.transform.position += new Vector3(0, 1.5f, 0);
					}else if (Input.GetKeyDown(KeyCode.W))
						{
							selection.transform.position += new Vector3(0, -1.5f, 0);
						}
		} else if (Input.GetKeyDown (KeyCode.J) && active == true) 
		{
			inventory.SetActive (false);
			selection.SetActive (true);
			active = false;
			Time.timeScale = 1;
		}
	}
}
