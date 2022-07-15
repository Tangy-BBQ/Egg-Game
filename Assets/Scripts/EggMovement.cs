using UnityEngine;
using System.Collections;

public class EggMovement : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    public bool canMove;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded() && canMove)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && canMove)
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && canMove)
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().rotation += moveVelocity * -.1f;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Toast")
        {
            canMove = false;
        }
    }

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}