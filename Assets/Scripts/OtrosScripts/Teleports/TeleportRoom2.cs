using UnityEngine;
using System.Collections;

public class TeleportRoom2 : MonoBehaviour 
{
    public GameObject player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.transform.position = new Vector3(5.7946f, 4.1982f, -0.4f);
        }
    }
}
