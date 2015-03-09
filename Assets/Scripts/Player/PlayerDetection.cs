using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour 
{
	public GameObject box;
	public GameObject carrito;

	private bool taking = false;

    void Update()
    { 

    }

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Box")
		{
			Debug.Log("Touching");
			if (Input.GetKey(KeyCode.F))
			{
				Debug.Log("Taking");
				box.transform.position = transform.position;
				taking = true;
                if (taking == true)
                    box.transform.position = transform.position;
			}
			if (Input.GetKey(KeyCode.E) && taking == true)
			{
				box.transform.position += new Vector3(0, 1.28f, 0);
				/*if(MOVEMENTDIRECTION.UP)
				{
					box.transform.position += new Vector3(0, -1.28f, 0);
				}
				if(MOVEMENTDIRECTION.DOWN)
				{
					box.transform.position += new Vector3(0, 1.28f, 0);
				}
				if(MOVEMENTDIRECTION.LEFT)
				{
					box.transform.position += new Vector3(-1.28f, 0, 0);
				}
				if(MOVEMENTDIRECTION.RIGHT)
				{
					box.transform.position += new Vector3(1.28f, 0, 0);
				}*/
			}
			else if (Input.GetKey(KeyCode.Q) && taking == true)
			{
				box.transform.position += new Vector3(0.32f, 0, 0);
			}
		}
		
		if (other.tag == "Carrito")
		{
			if (Input.GetKey(KeyCode.E))
			{
				carrito.transform.position += new Vector3(2.56f, 0, 0);
			}
		}
	}
}

