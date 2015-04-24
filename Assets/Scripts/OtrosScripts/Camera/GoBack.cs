using UnityEngine;
using System.Collections;

public class GoBack : MonoBehaviour 
{
    public GameObject player;
	
	void Update () 
    {
        if (player == null)
            Application.LoadLevel("Menu");
	}
}
