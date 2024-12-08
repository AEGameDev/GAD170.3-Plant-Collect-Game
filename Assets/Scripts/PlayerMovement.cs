using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controls Movement Speed of Player
    [Header("Move Speed")]
    public float moveSpeed = 5f;

    // Reference to Player Object Rigidbody
    private Rigidbody2D rb;

    // Movement Direction for Player Movement
    private Vector2 moveDirection;

    // Allows to Select Animator in Inspector (I Presonally Refernce in Start Function)
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Accessing Rigidbody Component on Player Object
        rb = GetComponent<Rigidbody2D>();

        // Accessing Animator & Setting Parameters of Animations to False to Begin With
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalkingHorizontal", false);
        animator.SetBool("IsWalkingVertical", false);
    }

    // Update is called once per frame
    void Update()
    {
        // This Allows me to Change Player Object Direction Later
        float horizontal = Input.GetAxis("Horizontal");

        // Movement Directions Based on X & Y Axis
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        // Triggers Animations & Changes Player Obj Rotation Based on Input
        if (Input.GetAxis("Horizontal") >0 || Input.GetAxis("Horizontal") <0)
        {
            animator.SetBool("IsWalkingHorizontal", true);
            Debug.Log("Player Moving Horizontally");
        }
        else
        {
            animator.SetBool("IsWalkingHorizontal", false);
        }

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("IsWalkingVertical", true);
            Debug.Log("Player Moving Verically");
        }
        else
        {
            animator.SetBool("IsWalkingVertical", false);
        }

        if (horizontal <0)
        {
            transform.localScale = new Vector3(-0.5f,0.5f,1);
            Debug.Log("Player Object Facing Left");
        }
        else
        {
             transform.localScale = new Vector3(0.5f,0.5f,1);
        }
    }

    private void FixedUpdate()
    {
        // Move Rigidbody Position Based on Pos + Speed + deltaTime * Direction
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveDirection);
    }
}
