using UnityEngine;
using System.Collections;

public class HierbaMedicinal : MonoBehaviour 
{
	public float range = 1.0f;
	public GameObject player;
	public GameObject curePS;
	public AudioClip HealSound;
	AudioSource audio;

	private bool activated = false;

	private GameObject healPs = null;



	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float viewDistance = Vector3.Distance(player.transform.position, transform.position);


		if (viewDistance <= range) 
		{
			if(Input.GetKeyDown(KeyCode.E) && !activated)
			{
				activated = true;
				NewPlayerMovement.life += 100;
				this.gameObject.GetComponent<MeshRenderer>().material.color = new Color (0,0,0,0);
				this.gameObject.transform.FindChild("MedPS").gameObject.SetActive(false);
				audio.PlayOneShot(HealSound,1);
				healPs = (GameObject) Instantiate(curePS, new Vector3 (player.transform.position.x, 
				                                 player.transform.position.y -0.5f
				                                 , -2), Quaternion.Euler(0, 0, 0));	

			}

		}
		healPs.transform.position = new Vector3 (player.transform.position.x, 
		                                         player.transform.position.y -0.5f
		                                         , -2);
	}
}
