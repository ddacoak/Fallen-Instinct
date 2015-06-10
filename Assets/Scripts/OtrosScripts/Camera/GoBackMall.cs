using UnityEngine;
using System.Collections;

public class GoBackMall : MonoBehaviour 
{
    public GameObject player;
	
	void Update () 
    {
        if (player == null)
			Application.LoadLevel ("Mall");
	}
}
