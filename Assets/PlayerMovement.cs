using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // PROCESSES INPUT
        ProcessInputs();
    }

    void FixedUpdate()
    {
        // MOVES THE PLAYER
        Move();
    }

    void ProcessInputs()
    {
        // PHYSICS PROCESSING
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(x, y).normalized;
    }

    void Move()
    {
        //! Set "isWalking" to true if there is movement, otherwise set to false
        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", moveDirection.x);
            animator.SetFloat("InputY", moveDirection.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
