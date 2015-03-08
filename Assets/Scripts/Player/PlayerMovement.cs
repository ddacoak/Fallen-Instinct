using UnityEngine;
using System.Collections;

// Possible movement directions
public enum MOVEMENTDIRECTION {UP,DOWN,LEFT,RIGHT,NONE};

public class PlayerMovement : MonoBehaviour
{
    public MOVEMENTDIRECTION movementDirection { get; private set; }
    MOVEMENTDIRECTION lookingTo;
    public WEAPON weapon { get; private set; }

    public GameObject bullet;
    public GameObject sword;

    private Vector3 movement;
    public float speed = 1;

    void Start()
    {
        //transform.position = new Vector3(0, 0, -1);
        movement = Vector3.zero;

        movementDirection = MOVEMENTDIRECTION.DOWN;
        lookingTo = MOVEMENTDIRECTION.DOWN;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
            speed = 2;
        else
            speed = 1;

        if (Input.GetKey(KeyCode.V))
            speed = 0.5f;
        else
            speed = 1;

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
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(root, root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-root, -root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(root, -root, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, speed, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.UP;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-speed, 0, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.LEFT;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = new Vector3(0, -speed, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.DOWN;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(speed, 0, 0) * Time.deltaTime;
            movementDirection = MOVEMENTDIRECTION.DOWN;
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
                    b.transform.position += new Vector3(0, 0.32f, 0);
                    break;
                case MOVEMENTDIRECTION.DOWN:
                    b.transform.position += new Vector3(0, -0.32F, 0);
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
    }
}