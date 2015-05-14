using UnityEngine;
using System.Collections;

// Possible movement directions
public enum MOVEMENTDIRECTION { UP, DOWN, LEFT, RIGHT, NONE };
public enum WEAPON {SWORD, BULLET};

public class PlayerMovement: MonoBehaviour
{
	Animator anim;
	private int valorCambio;

    private float spriteCounter = 0;
    private bool walk = false;

    public MOVEMENTDIRECTION movementDirection { get; private set; }
    MOVEMENTDIRECTION lookingTo;
    public WEAPON weapon { get; private set; }

    public GameObject bullet;
    public GameObject sword;

    private Vector3 movement;
    public float speed = 1;

	public GameObject blackPlane;

	private Rigidbody2D rigidBody;

	void Start () 
	{
		anim = GetComponent<Animator> ();

		//transform.position = new Vector3(0, 0, -1);
        movement = Vector3.zero;

        movementDirection = MOVEMENTDIRECTION.DOWN;
        lookingTo = MOVEMENTDIRECTION.DOWN;

		blackPlane.GetComponent<Renderer> ().material.color = new Color (0, 0, 0, 1);

		rigidBody = transform.GetComponent<Rigidbody2D> ();
	}

    void Update()
    {
        if (Input.GetKey(/*KeyCode.LeftShift*/KeyCode.C))
            speed = 4.5f;
		else if (Input.GetKey(/*KeyCode.LeftControl*/KeyCode.V))
            speed = 1;
        else
            speed = 2.5f;

        Movement();
        Attack();
    }

    void Movement()   //if(rigidBody.velocity.magnitude > maxspeed) 
    {
        bool isMoving = true;

        // Calculates the module of the speed
        float root = Mathf.Sqrt(speed * speed / 2);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //movement = new Vector3(-root, root, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(-root,root));
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //movement = new Vector3(root, root, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(root,root));
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            //movement = new Vector3(-root, -root, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(-root,-root));
            movementDirection = MOVEMENTDIRECTION.DOWN;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            //movement = new Vector3(root, -root, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(root,-root));
            movementDirection = MOVEMENTDIRECTION.DOWN;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            //movement = new Vector3(0, speed, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(0,speed));
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //movement = new Vector3(-speed, 0, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(-speed,0));
            movementDirection = MOVEMENTDIRECTION.LEFT;

			valorCambio = 4;
			anim.SetInteger("Transition", valorCambio);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            //movement = new Vector3(0, -speed, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(0,-speed));
            movementDirection = MOVEMENTDIRECTION.DOWN;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //movement = new Vector3(speed, 0, 0) * Time.deltaTime;
			rigidBody.velocity = (new Vector2(speed,0));
            movementDirection = MOVEMENTDIRECTION.RIGHT;

			valorCambio = 6;
			anim.SetInteger("Transition", valorCambio);

        }
        else
        {
			rigidBody.velocity =  Vector2.zero;

			isMoving = false;
            movementDirection = MOVEMENTDIRECTION.NONE;

			valorCambio = 5;
			anim.SetInteger("Transition", valorCambio);
        }

        if (movementDirection != MOVEMENTDIRECTION.NONE) lookingTo = movementDirection;

        //transform.Translate(movement);
        movement = Vector2.zero;
    }

    void Attack()
    {
        //MELEE ATTACK
        //----------
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject b;

            switch (weapon)
            {
                case WEAPON.SWORD: b = Instantiate(sword, transform.position, transform.rotation) as GameObject;
                    break;
                default:
                    b = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                    break;
            }

            FixedMove fm = b.GetComponent("FixedMove") as FixedMove;
            fm.movementDirection = lookingTo;

            switch (lookingTo)
            {
                case MOVEMENTDIRECTION.UP:
                    b.transform.position += new Vector3(0, 1.2f, 0);
                    break;
                case MOVEMENTDIRECTION.DOWN:
                    b.transform.position += new Vector3(0, -1.2f, 0);
                    b.transform.Rotate(0, 0, 180);
                    break;
                case MOVEMENTDIRECTION.LEFT:
                    b.transform.position += new Vector3(-0.64f, 0, 0);
                    b.transform.Rotate(0, 0, 90);
                    break;
                case MOVEMENTDIRECTION.RIGHT:
                    b.transform.position += new Vector3(0.64f, 0, 0);
                    break;
            }
        }

        //DISTANCE ATTACK
        //----------
        if (Input.GetKeyDown(KeyCode.O))
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
                    v.transform.position += new Vector3(0, 1, 0);
                    v.transform.Rotate(0, 0, 90);
                    break;
                case MOVEMENTDIRECTION.DOWN:
                    v.transform.position += new Vector3(0, -1, 0);
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
    }
}