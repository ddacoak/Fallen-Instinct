using UnityEngine;
using System.Collections;

public class DetectDeadZone : MonoBehaviour {

	private GameObject gameOver; //variable del gameover

	// variable gameovercheck bool
	private bool gameOverCheck;

	// VARIABLE PRIVADA LEVELLOGIC
	private LevelLogic levelLogic;


	// Use this for initialization
	void Start () {

		// BUSCO UN OBJETO EN LA ESCENA CON EL TAG LEVELLOGIC
		// COJO EL COMPONENTE CLASE LEVEL LOGIC
		levelLogic = GameObject.FindGameObjectWithTag ("LevelLogic").
			GetComponent<LevelLogic> ();

		gameOverCheck = false;

		// BUSCAMOS EL GAMEOBJECT DE GAMEOVER DENTRO DE LA MAIN CAMERA
		gameOver = Camera.main.transform.FindChild ("GameOver").
			gameObject;

		gameOver.SetActive(false); //desactiva el objeto game Over (transparencia)
	
	}

	void OnTriggerEnter(Collider other) { //detecta la colision

		if (other.tag == "Player") { //si colisiona con el player, 

			// LLAMAMOS A LA FUNCION GAMEOVER
			GameOver();
		
		}
	
	}

	void Update(){
		// SI GAMEOVERCHECK ES TRUE
		if (gameOverCheck==true) {
			// SI APRETAMOS EL BOTON ESPACIO EN EL GAMEOVER
			// CARGAMOS DE NUEVO EL NIVEL
			if(Input.GetButton("Jump"))
				levelLogic.loadCurrentLevel();
				//Application.LoadLevel(level);
		}

		// SI APRETAMOS LA TECLA ESC SE CIERRA EL JUEGO
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}

	}

	// FUNCION GAMEOVER: ACTIVA EL GAMEOVER
	public void GameOver(){
		// activa el GameOver
		gameOver.SetActive(true);

		gameOverCheck = true;

	}





}
