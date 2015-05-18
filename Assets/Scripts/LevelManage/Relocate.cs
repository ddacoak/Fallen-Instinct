using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class Relocate : MonoBehaviour
{
	public bool activate = false;

	void Update () 
	{
		if (!Application.isPlaying && activate)
		{
			foreach(Transform child in transform)
				child.transform.position += transform.localPosition;

			transform.position = Vector3.zero;

			activate = false;
		}
	}
}
