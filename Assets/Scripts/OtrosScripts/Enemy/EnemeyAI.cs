using UnityEngine;
using System.Collections;

public class EnemeyAI : MonoBehaviour 
{
	Animator anim;
	private int valorCambio;

    public float speed = 0.5f;
	public float range = 10.0f;
    public GameObject player;
	public GameObject footprints1;
	public GameObject footprints2;
	public GameObject footprints3;
	private float footprintsCounter = 0f;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
    {
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  transform.position.y / 100.0f - 1.0f);

		float viewDistance = Vector3.Distance(player.transform.position, transform.position);

		if(viewDistance>=range)
		{
			valorCambio = 0;

		}

        if (viewDistance <= range)
        {
			footprintsCounter++;

			anim.SetInteger("Transition", valorCambio);

            if (player.transform.position.x >= transform.position.x)
			{
				valorCambio = 2;

				transform.position += new Vector3(speed,0,0) * Time.deltaTime;
				if (footprintsCounter >= 100)
				{
					Instantiate(footprints1, new Vector3(transform.position.x, transform.position.y - 0.70f, transform.position.z), Quaternion.identity);
					footprintsCounter = 0;
				}
			}
            else if (player.transform.position.x <= transform.position.x)
			{
				valorCambio = 1;

				transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
				if (footprintsCounter >= 100)
				{
					Instantiate(footprints1, new Vector3(transform.position.x, transform.position.y - 0.70f, transform.position.z), Quaternion.identity);
					footprintsCounter = 0;
				}
			}

            if (player.transform.position.y >= transform.position.y)
			{
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
				if (footprintsCounter >= 100)
				{
					Instantiate(footprints1, new Vector3(transform.position.x, transform.position.y - 0.70f, transform.position.z), Quaternion.identity);
					footprintsCounter = 0;
				}
			}
            else if (player.transform.position.y <= transform.position.y)
			{
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
				if (footprintsCounter >= 100)
				{
					Instantiate(footprints1, new Vector3(transform.position.x, transform.position.y - 0.70f, transform.position.z), Quaternion.identity);
					footprintsCounter = 0;
				}
			}


			Debug.Log(transform.position.y);
			Debug.Log(player.transform.position.y);
			anim.SetInteger("Transition", valorCambio);
        }
		anim.SetInteger("Transition", valorCambio);
	}
}
