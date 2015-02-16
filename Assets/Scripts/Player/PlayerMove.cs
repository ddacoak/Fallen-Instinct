using UnityEngine;
using System.Collections;

// Possible movement directions
public enum MOVEMENTDIRECTION {UP,DOWN,LEFT,RIGHT,NONE};
// Weapons
public enum WEAPON {SWORD,BULLET,LASTWEAPON};

public class PlayerMove : MonoBehaviour 
{
	public MOVEMENTDIRECTION movementDirection {get; private set;}
	MOVEMENTDIRECTION lookingTo;
	public WEAPON weapon {get; private set;}

	public GameObject bullet,sword;
    public GameObject player;
    public GameObject box;

	public float speed = 0.05f;
    public float rSpeed = 0.075f;

	bool inventoryMode = false;

	void Start () 
    {
		movementDirection = MOVEMENTDIRECTION.DOWN;
		lookingTo = MOVEMENTDIRECTION.DOWN;
	}

	void Update () 
    {
		if (RoomManager.Instance.Pause) return;

        //Throw box
        if ((Input.GetKeyUp(KeyCode.K)) && (player.collider2D))
        {
            if (Input.GetKeyUp(KeyCode.J))
            { 
                
            }

            if (Input.GetKeyUp(KeyCode.L))
            {

            }
        }

		// Inventory and map screen interaction WORK IN PROGRESS
		if (Input.GetKeyUp (KeyCode.P)) 
        {
			if (inventoryMode) {
				RoomManager.Instance.Inventory.SetActive(false);
				inventoryMode = false;
			} else {
				RoomManager.Instance.Inventory.SetActive(true);
				inventoryMode = true;
			}
		}
		if (inventoryMode) 
        {
			if (Input.GetKeyUp (KeyCode.D)) 
            {
				weapon++;
				if (weapon == WEAPON.LASTWEAPON) weapon = 0;
			} else
			if (Input.GetKeyUp (KeyCode.A)) 
            {
				weapon--;
				if (weapon < 0) weapon = WEAPON.LASTWEAPON-1;
			}
			GameObject selector = GameObject.Find ("selector");
			GameObject selectorStart = GameObject.Find ("selectorstart");
			selector.transform.position = selectorStart.transform.position + new Vector3((float)weapon,0,-4); 
		} else 
        {
			checkAction();
		}
	}

	void FixedUpdate () 
    {
		if (RoomManager.Instance.Pause) return;

		//WALK
        //----------
		if (Input.GetKey (KeyCode.W)) 
        {
			transform.position += new Vector3(0,speed,0);
			movementDirection = MOVEMENTDIRECTION.UP;
		} else
		if (Input.GetKey (KeyCode.S)) 
        {
			transform.position += new Vector3(0,-speed,0);
			movementDirection = MOVEMENTDIRECTION.DOWN;
		} else
		if (Input.GetKey (KeyCode.A)) 
        {
			transform.position += new Vector3(-speed,0,0);
			movementDirection = MOVEMENTDIRECTION.LEFT;
		} else
		if (Input.GetKey (KeyCode.D)) 
        {
			transform.position += new Vector3(speed,0,0);
			movementDirection = MOVEMENTDIRECTION.RIGHT;
		} else 
			movementDirection = MOVEMENTDIRECTION.NONE;
        
		if (movementDirection!=MOVEMENTDIRECTION.NONE) lookingTo = movementDirection;
        //----------

        //RUN
        //----------
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.C)))
        {
            transform.position += new Vector3(0, speed, 0);
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else
            if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.C)))
            {
                transform.position += new Vector3(0, -speed, 0);
                movementDirection = MOVEMENTDIRECTION.DOWN;
            }
            else
                if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.C)))
                {
                    transform.position += new Vector3(-speed, 0, 0);
                    movementDirection = MOVEMENTDIRECTION.LEFT;
                }
                else
                    if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.C)))
                    {
                        transform.position += new Vector3(speed, 0, 0);
                        movementDirection = MOVEMENTDIRECTION.RIGHT;
                    }
                    else
                        movementDirection = MOVEMENTDIRECTION.NONE;

        if (movementDirection != MOVEMENTDIRECTION.NONE) lookingTo = movementDirection;
        //----------
	}

	//USE WEAPON
	void checkAction() 
    {
        //MELEE ATTACK
        //----------
		if (Input.GetKeyUp (KeyCode.I)) 
        {
			GameObject b;

			switch(weapon) 
            {
			case WEAPON.SWORD: b = Instantiate(sword,transform.position,transform.rotation) as GameObject;
				break;
			default:
				b = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
				break;
			}
			
			FixedMove fm = b.GetComponent("FixedMove") as FixedMove;
			fm.movementDirection = lookingTo;
			
			switch(lookingTo) 
            {
			case MOVEMENTDIRECTION.UP: 								
				b.transform.position+=new Vector3(0,0.32f,0);			
				break;
			case MOVEMENTDIRECTION.DOWN: 
				b.transform.position+=new Vector3(0,-0.32F,0);
				b.transform.Rotate(0,0,180);
				break;
			case MOVEMENTDIRECTION.LEFT: 
				b.transform.position+=new Vector3(-0.32f,0,0);
				b.transform.Rotate(0,0,90);
				break;
			case MOVEMENTDIRECTION.RIGHT: 
				b.transform.position+=new Vector3(0.32f,0,0);
				break;
			}
	    }
        //----------

            //DISTANCE ATTACK
            //----------
            if (Input.GetKeyUp(KeyCode.O))
            {
                GameObject v;

                switch (weapon)
                {
                    case WEAPON.BULLET: v = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                        break;
                    default:
                        v = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                        break;
                }

                FixedMove fm2 = v.GetComponent("FixedMove") as FixedMove;
                fm2.movementDirection = lookingTo;

                switch (lookingTo)
                {
                    case MOVEMENTDIRECTION.UP:
                        v.transform.position += new Vector3(0, 0.32f, 0);
                        v.transform.Rotate(0, 0, 90);
                        break;
                    case MOVEMENTDIRECTION.DOWN:
                        v.transform.position += new Vector3(0, -0.32F, 0);
                        v.transform.Rotate(0, 0, -90);
                        break;
                    case MOVEMENTDIRECTION.LEFT:
                        v.transform.position += new Vector3(-0.32f, 0, 0);
                        v.transform.Rotate(0, 0, 180);
                        break;
                    case MOVEMENTDIRECTION.RIGHT:
                        v.transform.position += new Vector3(0.32f, 0, 0);
                        break;
            }
        }
        //----------
	}
}