using UnityEngine;
using System.Collections;

public class Cepos : MonoBehaviour 
{
    public Texture open;
    public Texture close;

	void Start () 
    {
        renderer.material.mainTexture = open;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            renderer.material.mainTexture = close;
        }
    }
}
