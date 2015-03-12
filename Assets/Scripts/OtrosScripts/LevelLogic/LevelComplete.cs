using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	public GameObject levelComplete; 

	// variable levelCompleteCheck bool
	private bool levelCompleteCheck;

	// VARIABLE PRIVADA LEVELLOGIC
	private LevelLogic levelLogic;


	// Use this for initialization
	void Start () {

		// BUSCO UN OBJETO EN LA ESCENA CON EL TAG LEVELLOGIC
		// COJO EL COMPONENTE CLASE LEVEL LOGIC
		levelLogic = GameObject.FindGameObjectWithTag ("LevelLogic").
			GetComponent<LevelLogic> ();

		levelCompleteCheck = false;
		// BUSCAMOS EL GAMEOBJECT DE LEVELCOMPLETE DENTRO DE LA MAIN CAMERA
		levelComplete = Camera.main.transform.FindChild ("LevelComplete").
			gameObject;
		//desactiva el objeto LEVEL COMPLETE 
		levelComplete.SetActive(false); 
	}

	void OnTriggerEnter(Collider other) { //detecta la colision

		if (other.tag == "Player") { //si colisiona con el player, 

			// LLAMAMOS A LA FUNCION LEVELPASS
			LevelPass();
		
		}
	
	}

	void Update(){
		// SI GAMEOVERCHECK ES TRUE
		if (levelCompleteCheck==true) {
			// SI APRETAMOS EL BOTON ESPACIO EN EL GAMEOVER
			// CARGAMOS DE NUEVO EL NIVEL
			if(Input.GetButton("Jump")){
				// Cargo el siguiente nivel en LevelLogic
				levelLogic.loadNextLevel();
			}
		}

	}
	// FUNCION LEVEL PASS: ACTIVA EL LEVEL COMPLETE
	public void LevelPass(){
		// activa el GameObject Level Complete
		levelComplete.SetActive(true);
		// lo checkea a true
		levelCompleteCheck = true;

	}





}
