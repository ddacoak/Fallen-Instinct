using UnityEngine;
using System.Collections;

public class Cepos : MonoBehaviour 
{
	Animator anim;
	private int valorCambio = 0;

	public GameObject playerShadow;
	public float range = 0.5f;

	public GameObject player;

	//Damage
	public int power = 100;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		float viewDistance = Vector3.Distance(playerShadow.transform.position, transform.position);

		if (viewDistance <= range) 
		{
			valorCambio = 1;
			anim.SetInteger("Detect", valorCambio);
		}

		//DetectCollision (other:gameObject);
	}

	/*void DetectCollision(GameObject other) 
	{
		Life otherLife = other.GetComponent("Life") as Life;

		if (valorCambio == 1)
		{
			Life myLife = gameObject.GetComponent("Life") as Life;
			//If I am alive, and the other object is not a weapon attack and the other object 
			//aligment is different to mine does damage
			if (myLife.life>0 && otherLife.type!=TYPE.WEAPON &&	otherLife.aligment!=myLife.aligment)
				otherLife.Hit(power);
		}
	}*/
}
