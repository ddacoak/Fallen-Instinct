using UnityEngine;
using System.Collections;

public enum ITEMTYPE { LIFE };

public class Item : MonoBehaviour 
{
	public ITEMTYPE type;

	void OnTriggerEnter2D(Collider2D other) 
    {
		if (other.name=="Player") 
        {
            Debug.Log("Touching");
            switch (type)
            {
                case ITEMTYPE.LIFE:
                    Life life = other.gameObject.GetComponent("Life") as Life;
                    life.IncrementLife(150);
                    Destroy(gameObject);
                    break;
            }
		}
	}
}
