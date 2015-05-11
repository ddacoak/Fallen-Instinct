using UnityEngine;
using System.Collections;

public class EnemeyAI : MonoBehaviour 
{
    public float speed = 0.5f;
	public float range = 3.0f;
    public GameObject player;
	
	void Update () 
    {
        float viewDistance = Vector3.Distance(player.transform.position, transform.position);

        if (viewDistance <= range)
        {
            if (player.transform.position.x >= transform.position.x)
                transform.position += new Vector3(speed,0,0) * Time.deltaTime;
            else if (player.transform.position.x <= transform.position.x)
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (player.transform.position.y >= transform.position.y)
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            else if (player.transform.position.y <= transform.position.y)
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
	}
}
