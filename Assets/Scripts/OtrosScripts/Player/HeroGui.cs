using UnityEngine;
using System.Collections;

public class HeroGui : MonoBehaviour 
{
	Life myLife;
	PlayerMovement pm;
	GameObject h1,h2,h3;
	GameObject[] weaponsgui;

	void Start () 
    {
		pm = gameObject.GetComponent("PlayerMove") as PlayerMovement;
		myLife = gameObject.GetComponent("Life") as Life;
		h1 = GameObject.Find("heart100");
		h2 = GameObject.Find("heart200");
		h3 = GameObject.Find("heart300");
	}

	void Update () 
    {
		h1.SetActive( (myLife.life>=100) );  
		h2.SetActive( (myLife.life>=200) );
		h3.SetActive( (myLife.life>=300) );
	}
}
