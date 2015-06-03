using UnityEngine;
using System.Collections;

public class GateBehaviour : MonoBehaviour {

	public GameObject gate;
	public GameObject player;


	public float speed;
	private float min;
	public float max = 0.7f;
	public float currentY;

	public bool open = false;

	public AudioClip gateMoving;
	public AudioClip gateClosed;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		min = 0.0f;
		max = 0.7f;
		currentY = gate.transform.localPosition.y;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		currentY = gate.transform.localPosition.y;

		if (open) {
			if (gate.transform.localPosition.y <= max)
				currentY += speed;
			else audio.Stop();
		}


		else {
			if (gate.transform.localPosition.y >= min)
				currentY -= speed;
			else audio.Stop();
		}

		gate.transform.localPosition = new Vector3(gate.transform.localPosition.x, currentY, gate.transform.localPosition.z);

		//Debug.Log (currentY);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log("Collides");
			open = true;
			audio.Stop();
			audio.PlayOneShot(gateMoving,1);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log("Out");
			open = false;
			audio.Stop();
			audio.PlayOneShot(gateMoving,1);
		}
	}
}
