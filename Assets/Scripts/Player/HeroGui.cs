using UnityEngine;
using System.Collections;

public class HeroGui : MonoBehaviour 
{
	Life myLife;
	PlayerMove pm;
	GameObject h1,h2,h3;
	GameObject[] weaponsgui;

	void Start () 
    {
		pm = gameObject.GetComponent("PlayerMove") as PlayerMove;
		myLife = gameObject.GetComponent("Life") as Life;
		h1 = GameObject.Find("hearth100");
		h2 = GameObject.Find("hearth200");
		h3 = GameObject.Find("hearth300");
	}

	void Update () 
    {
		h1.SetActive( (myLife.life>=100) );  
		h2.SetActive( (myLife.life>=200) );
		h3.SetActive( (myLife.life>=300) );
	}
}
