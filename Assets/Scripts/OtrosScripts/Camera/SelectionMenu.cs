using UnityEngine;
using System.Collections;

public class SelectionMenu : MonoBehaviour 
{
	public GameObject selection;
	public GameObject playButton;
	public GameObject optionsButton;
	public GameObject creditsButton;
	public GameObject exitButton;

	void Update () 
	{
		if (selection.transform.position == new Vector3 (0, 1.5f, 0)) 
		{
			if (Input.GetKeyDown (KeyCode.W)) 
				selection.transform.position = new Vector3 (0,0,0);
		}

		if (selection.transform.position == new Vector3 (0, -3, 0)) 
		{
			if (Input.GetKeyDown (KeyCode.S)) 
				selection.transform.position = new Vector3 (0,0,0);
		}

		if (Input.GetKeyDown (KeyCode.W)) 
		{
			selection.transform.position += new Vector3 (0, 1.5f, 0);
		} else if (Input.GetKeyDown (KeyCode.S)) 
		{
			selection.transform.position += new Vector3 (0, -1.5f, 0);
		}

		if (Input.GetKeyDown (KeyCode.E) && selection.transform.position == new Vector3 (0, 1.5f, 0))
			Application.LoadLevel ("Loading");

        if (Input.GetKeyDown(KeyCode.E) && selection.transform.position == new Vector3(0, 0, 0))
            Application.LoadLevel("Loading");

        if (Input.GetKeyDown(KeyCode.E) && selection.transform.position == new Vector3(0, -1.5f, 0))
            Application.LoadLevel("Credits");

        if (Input.GetKeyDown(KeyCode.E) && selection.transform.position == new Vector3(0, 3, 0))
            Application.Quit();
	}
}
