using UnityEngine;
using System.Collections;

public class GoBackMall2 : MonoBehaviour 
{
    public GameObject player;
	
	void Update () 
    {
        if (player == null)
            Application.LoadLevel("Mall 2");
	}
}
