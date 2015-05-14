using UnityEngine;
using System.Collections;

public class SelectionMenu : MonoBehaviour 
{
	private GameObject selection;
	public GameObject playButton;
	public GameObject optionsButton;
	public GameObject creditsButton;
	public GameObject exitButton;

	private bool pressed = false;
	private float framesCounter = 1;

	void Start()
	{
		selection = this.gameObject;
		selection.transform.position = playButton.transform.position;
	}

	void Update() 
	{
		if (pressed) framesCounter -= Time.deltaTime *10;
		if (framesCounter <= 0) 
		{
			pressed = false;
			framesCounter = 1;
		}

		if (selection.transform.position == playButton.transform.position) 
		{
			//Debug.Log("Play");
			if (Input.GetKeyDown (KeyCode.S) && !pressed) {
				selection.transform.position = optionsButton.transform.position;
				pressed = true;
			}
				
			else if (Input.GetKeyDown (KeyCode.W) && !pressed)
			{
				selection.transform.position = exitButton.transform.position;
				pressed = true;
			}
			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel ("Loading");
		}

		if (selection.transform.position == optionsButton.transform.position) 
		{
			//Debug.Log("Options");
			if (Input.GetKeyDown (KeyCode.W) && !pressed)
			{
				selection.transform.position = playButton.transform.position;
				pressed = true;
			}
			else if (Input.GetKeyDown (KeyCode.S) && !pressed) 
			{
				selection.transform.position = creditsButton.transform.position;
				pressed = true;
			}
			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel("Credits");
		}

		if (selection.transform.position == creditsButton.transform.position) 
		{
			//Debug.Log("Credits");
			if (Input.GetKeyDown (KeyCode.W) && !pressed) 
			{
				selection.transform.position = optionsButton.transform.position;
				pressed = true;
			}
			else if (Input.GetKeyDown (KeyCode.S) && !pressed) 
			{
				selection.transform.position = exitButton.transform.position;
				pressed = true;
			}

			if (Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel("Credits");
		}

		if (selection.transform.position == exitButton.transform.position) 
		{
			//Debug.Log("Exit");
			if (Input.GetKeyDown (KeyCode.W) && !pressed)
			{
				selection.transform.position = creditsButton.transform.position;
				pressed = true;
				Debug.Log("sale");
			}
			else if (Input.GetKeyDown (KeyCode.S) && !pressed) 
			{
				selection.transform.position = playButton.transform.position;
				pressed = true;
			}

			if (Input.GetKeyDown (KeyCode.E))
				Application.Quit();
		}
	}
}
