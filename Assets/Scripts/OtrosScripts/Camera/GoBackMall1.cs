using UnityEngine;
using System.Collections;

public class GoBackMall1 : MonoBehaviour 
{
    public GameObject player;
	
	void Update () 
    {
        if (player == null)
            Application.LoadLevel("Mall 1");
	}
}
