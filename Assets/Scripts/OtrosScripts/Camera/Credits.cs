using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel("Menu");
        }
	}
}
