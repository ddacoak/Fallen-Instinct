using UnityEngine;
using System.Collections;

public class TeleportRoom1 : MonoBehaviour 
{
    public GameObject player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.transform.position = new Vector3(0.01f, 3.79f, -0.4f);
        }
    }
}
