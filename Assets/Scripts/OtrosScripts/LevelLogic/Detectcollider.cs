using UnityEngine;
using System.Collections;

public class Detectcollider : MonoBehaviour {

	public Transform blood; //transform es saber la coordenada del objeto
	//public TextMesh textLife; //creas texLife

	public Transform star;

	public TextMesh textCoin;

	// VARIABLE PUBLICA DE CLASE DETECTDEADZONE
	public DetectDeadZone dead;

	void Start(){
		dead = Camera.main.transform.FindChild("Dead Zone").GetComponent<DetectDeadZone>();
	}


	void OnTriggerEnter(Collider other) {

		// SI TOCA BOSS
		if (other.tag == "Boss") {
			// LLAMO AL GAME OVER
			dead.GameOver();
		}

		if (other.tag == "Saw") {
			// LLAMO AL GAME OVER
			dead.GameOver();
		}

		if(other.tag=="Enemy"){
		
		GameObject bl= (GameObject)Instantiate(blood.gameObject,transform.position,Quaternion.identity); //blood (objeto que se va a crear)posicion del collider del otro (si pones other.position sera la caja) y el quaternion son angulos a cero
		Destroy(bl,2); //bl= blood 2=segundos antes de k se destruya (Esto es para destruir el crack de la sangre k hay en hierarchy y no se acumule

		// LLAMO AL GAME OVER
		dead.GameOver();

		Destroy(other.gameObject); //destruye la caja
		}

		if(other.tag=="Coin"){
			Debug.Log ("MATAS A:" +other.name);
			GameObject str= (GameObject)Instantiate(star.gameObject,transform.position,Quaternion.identity);
			Destroy(str,2);

			//Mira el texto del Coin, lo sustituye y le suma 1
			textCoin.text = (int.Parse(textCoin.text)+1).ToString();

			//Destruye la moneda
			Destroy(other.gameObject);
		}


	}
}
