using UnityEngine;
using System.Collections;

public class CarritoBehaviour : MonoBehaviour {

	private Vector3 curPos;
	private Vector3 lastPos;
	private bool instantiatePrefab = false;
	public GameObject sparkPs;
	private GameObject spark;
	private float framesCounter = 0;

	private float playerMinSpeed = 0.03f;
	private float enemyMinSpeed = 0.015f;
	private float carritoMinSpeed;

	public AudioClip shoppingCartSound;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		curPos = new Vector3 (transform.position.x,
		                      transform.position.y,
		                      transform.position.y / 100.0f - 0.995f);
		lastPos = curPos;

		spark = (GameObject)Instantiate(sparkPs, new Vector3 (transform.position.x, 
		                                                      transform.position.y
		                                                      , -1), Quaternion.Euler(0, 0, 0));	
		spark.SetActive(false);

		audio = GetComponent<AudioSource>();
		audio.volume = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  transform.position.y / 100.0f - 0.995f);

		framesCounter += Time.deltaTime;
		//Debug.Log (framesCounter);
		
		curPos = transform.position;

		if (curPos.x <= lastPos.x + 0.03f && curPos.x >= lastPos.x - 0.03f &&
		    curPos.y <= lastPos.y + 0.03f && curPos.y >= lastPos.y - 0.03f &&
		    curPos.z <= lastPos.z + 0.03f && curPos.z >= lastPos.z - 0.03f) 
		{
			if(framesCounter >= 0.5f)
			{
				//Debug.Log ("Not Moving");
				instantiatePrefab = false;
				spark.SetActive(false);
				
				framesCounter = 0;

				if(audio.volume > 0f) audio.volume -= 0.5f;
				else audio.volume = 0f;
			}
			
		} else 
		{
			//Debug.Log ("Moving");
			if(!instantiatePrefab)
			{ 
				spark.SetActive(true);
				instantiatePrefab = true;
				
			}
			spark.transform.position = new Vector3 (transform.position.x, 
			                                        transform.position.y
			                                        , -1);
			if(audio.volume < 1f)audio.volume += 0.05f;
			else audio.volume = 1f;
		}

		lastPos = curPos;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//carritoMinSpeed = playerMinSpeed;
			Debug.Log ("touches PLAYER");

		}
		
	}
	
}

	
