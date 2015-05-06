using UnityEngine;
using System.Collections;

public class ButonBehaviour : MonoBehaviour {
	// VARIABLE PUBLICA STRING LEVELNAME
	public string levelName;

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
		// CARGO EL NIVEL levelName
		Application.LoadLevel (levelName);
	}	
}
