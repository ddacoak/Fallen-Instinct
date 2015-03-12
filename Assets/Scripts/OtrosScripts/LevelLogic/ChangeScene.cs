using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
    private float counterToScene = 0;

	void Update () 
    {
        counterToScene++;
        Debug.Log(counterToScene);
        
        if (counterToScene >= 300)
            Application.LoadLevel("Mall");
	}
}
