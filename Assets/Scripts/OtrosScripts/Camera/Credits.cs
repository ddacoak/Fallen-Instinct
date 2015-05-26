using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
{
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("Menu");
        }
	}
}
