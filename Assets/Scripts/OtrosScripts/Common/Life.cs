using UnityEngine;
using System.Collections;

public enum ALIGMENT {PLAYER,ENEMY};
public enum TYPE {HERO,ENEMY_ZOMBIE,BOX,WEAPON}

public class Life : MonoBehaviour {

	public TYPE type;
	public ALIGMENT aligment;
	public int life = 100;
	public int maxLife = 300;
    
    public GameObject player;
	private float damageFeedback = 0;

	public GameObject createWhenDestroyed=null;

	public void IncrementLife(int qty) {
		life+=qty;
		if (life>maxLife) life = maxLife;
	}

	public void Hit(int power) 
    {
		life -= power;

		if (player) 
		{
			Debug.Log("Auch!");
			//PlayerDamage();
		}

		if (life<=0) {
			//Player will not die for now
			if (name!="Player") 
            {
				//And destroy after some time
				Destroy(gameObject,0.3f);
				// If there is something to create, instantiate it
				if (createWhenDestroyed) {
					Instantiate(createWhenDestroyed,gameObject.transform.position,gameObject.transform.rotation);
				}
			}
            if (player)
            {
				Destroy(gameObject, 3);
            }
		} 
	}
	
	public void PlayerDamage()
	{
		Debug.Log ("Damage Feedback");
		damageFeedback++;

		if(damageFeedback <= 2)
		{
			GetComponent<Renderer> ().material.color = new Color(1, 0, 0, 1);
		}
		if(damageFeedback <= 32)
		{
			GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 1);
		} 
		if(damageFeedback <= 64)
		{
			GetComponent<Renderer> ().material.color = new Color(1, 0, 0, 1);
		}
		if(damageFeedback <= 96)
		{
			GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 1);
			damageFeedback = 0;
			return;
		}
	}
}
