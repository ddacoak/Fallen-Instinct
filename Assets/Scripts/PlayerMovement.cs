using UnityEngine;
using System.Collections;

// Possible movement directions
public enum MOVEMENTDIRECTION { UP, DOWN, LEFT, RIGHT, NONE };

public class PlayerMovement: MonoBehaviour
{
	public Texture idle;
	public Texture idleLeft;
	public Texture idleRight;
    public Texture walkFront;
    public Texture walkLeft;
    public Texture walkRight;

    private float spriteCounter = 0;
    private bool walk = false;

    public MOVEMENTDIRECTION movementDirection { get; private set; }
    MOVEMENTDIRECTION lookingTo;
    public WEAPON weapon { get; private set; }

    public GameObject bullet;
    public GameObject sword;

    private Vector3 movement;
    public float speed = 1;
	
	void Start () 
	{
        //transform.position = new Vector3(0, 0, -1);
        movement = Vector3.zero;

        movementDirection = MOVEMENTDIRECTION.DOWN;
        lookingTo = MOVEMENTDIRECTION.DOWN;
	}

    void Update()
    {
        spriteCounter++;

        if (spriteCounter >= 20 && walk == false)
        {
            walk = true;
            spriteCounter = 0;
        }else if (spriteCounter >= 20 && walk == true)
            {
                walk = false;
                spriteCounter = 0;
            }

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 3.5f;
        else if (Input.GetKey(KeyCode.LeftControl))
            speed = 1;
        else
            speed = 2.5f;

        Movement();
        Attack();
    }

    void Movement()
    {
        bool isMoving = true;

        // Calculates the module of the speed
        float root = Mathf.Sqrt(speed * speed / 2);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-root, root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(root, root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-root, -root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.DOWN;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront; 
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(root, -root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.DOWN;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, speed, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-speed, 0, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.LEFT;
            if (walk == false)
                renderer.material.mainTexture = idleLeft;
            else if (walk == true)
                renderer.material.mainTexture = walkLeft;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = new Vector3(0, -speed, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.DOWN;
            if (walk == false)
                renderer.material.mainTexture = idle;
            else if (walk == true)
                renderer.material.mainTexture = walkFront;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(speed, 0, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.RIGHT;
            
            if(walk==false)
                renderer.material.mainTexture = idleRight;
            else if (walk==true)
                renderer.material.mainTexture = walkRight;
        }
        else
        {
            isMoving = false;
            movementDirection = MOVEMENTDIRECTION.NONE;
        }

        if (movementDirection != MOVEMENTDIRECTION.NONE) lookingTo = movementDirection;

        transform.Translate(movement);
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
                    b.transform.position += new Vector3(0, 1, 0);
                    break;
                case MOVEMENTDIRECTION.DOWN:
                    b.transform.position += new Vector3(0, -1, 0);
                    b.transform.Rotate(0, 0, 180);
                    break;
                case MOVEMENTDIRECTION.LEFT:
                    b.transform.position += new Vector3(-0.32f, 0, 0);
                    b.transform.Rotate(0, 0, 90);
                    break;
                case MOVEMENTDIRECTION.RIGHT:
                    b.transform.position += new Vector3(0.32f, 0, 0);
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