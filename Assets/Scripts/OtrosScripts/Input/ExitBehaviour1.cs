using UnityEngine;
using System.Collections;

public class ExitBehaviour : MonoBehaviour {

	// ACTIVAMOS EL EVENTO ONDOWN
	void OnEnable(){
		GetComponent<InputBehaviour>().onDown += onDown;
	}
	
	// DESACTIVAMOS EL EVENTO ONDOWN
	void OnDisable(){
		GetComponent<InputBehaviour>().onDown -= onDown;
	}

	// QUÉ HACE EL EVENTO ONDOWN ???
	void onDown(int number){
		// SALIR DEL JUEGO
		Application.Quit ();
	}	
}
