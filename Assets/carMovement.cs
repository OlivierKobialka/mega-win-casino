using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject pointA;  // Start point
    public GameObject pointB;  // End point
    private Rigidbody2D rb;

    private Transform currentPoint;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform; // Start moving towards pointB
    }

    void Update()
    {
        // Calculate the direction vector towards the current point
        Vector2 direction = currentPoint.position - transform.position;

        // Normalize the direction to get a unit vector and multiply by speed
        rb.linearVelocity = direction.normalized * speed;

        // Check if the car has reached the current target point
        if (Mathf.Abs(direction.y) < 0.1f) // Adjust threshold as necessary
        {
            // If the car is at pointB, make it disappear
            if (currentPoint == pointB.transform)
            {
                gameObject.SetActive(false);
            }
            else
            {
                // Switch to pointB if the current point is pointA
                currentPoint = pointB.transform;
            }
        }
    }

    // Method to initialize movement settings
    public void Initialize(GameObject startPoint, GameObject endPoint, float moveSpeed)
    {
        pointA = startPoint;
        pointB = endPoint;
        speed = moveSpeed;
    }
}
