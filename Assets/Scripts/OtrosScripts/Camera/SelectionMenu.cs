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
		if (selection.transform.position == playButton.transform.position) 
		{
			Debug.Log("Play");
			if (Input.GetKeyDown (KeyCode.S)) 
				selection.transform.position = optionsButton.transform.position;

			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel ("Loading");
		}

		if (selection.transform.position == optionsButton.transform.position) 
		{
			Debug.Log("Options");
			if (Input.GetKeyDown (KeyCode.W)) 
				selection.transform.position = playButton.transform.position;
			else if (Input.GetKeyDown (KeyCode.S)) 
				selection.transform.position = creditsButton.transform.position;

			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel("Credits");
		}

		if (selection.transform.position == creditsButton.transform.position) 
		{
			Debug.Log("Credits");
			if (Input.GetKeyDown (KeyCode.W)) 
				selection.transform.position = optionsButton.transform.position;
			else if (Input.GetKeyDown (KeyCode.S)) 
				selection.transform.position = exitButton.transform.position;

			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel("Credits");
		}

		if (selection.transform.position == exitButton.transform.position) 
		{
			Debug.Log("Exit");
			if (Input.GetKeyDown (KeyCode.W)) 
				selection.transform.position = creditsButton.transform.position;

			if (Input.GetKeyDown (KeyCode.E))
				Application.Quit();
		}
	}
}
