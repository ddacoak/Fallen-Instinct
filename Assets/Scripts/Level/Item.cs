using UnityEngine;
using System.Collections;

public enum ITEMTYPE { LIFE };

/*
Attach to pick up items
*/

public class Item : MonoBehaviour 
{
	public ITEMTYPE type;

	void OnTriggerEnter2D(Collider2D other) 
    {
		if (other.gameObject.name=="hero") 
        {
			switch (type) {
				case ITEMTYPE.LIFE:
					Life life = other.gameObject.GetComponent("Life") as Life;
					life.IncrementLife(100);
					Destroy(gameObject);
				break;
			}

		}
	}
}
