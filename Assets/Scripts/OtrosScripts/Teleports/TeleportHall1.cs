using UnityEngine;
using System.Collections;

public class TeleportHall1 : MonoBehaviour 
{
    public GameObject player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.transform.position = new Vector3(-4.91f, 23.41f, -0.4f);
        }
    }
}
