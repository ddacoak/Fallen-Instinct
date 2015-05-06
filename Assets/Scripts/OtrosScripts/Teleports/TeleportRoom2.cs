using UnityEngine;
using System.Collections;

public class TeleportRoom2 : MonoBehaviour 
{
    public GameObject player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.transform.position = new Vector3(6.0f, 3.8f, -0.4f);
        }
    }
}
