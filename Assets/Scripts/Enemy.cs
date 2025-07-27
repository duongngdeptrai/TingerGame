using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Speed of the enemy movement
    [SerializeField] private float distance = 5f; // Distance the enemy will patrol
    private Vector3 startPosition; // Starting position of the enemy
    private bool movingRight = true; // Direction the enemy is currently moving
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // Store the starting position of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPosition.x - distance; // Calculate the left boundary
        float rightBound = startPosition.x + distance; // Calculate the right boundary
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Move right
            if (transform.position.x >= rightBound) // Check if the enemy has reached the right boundary
            {
                movingRight = false; // Change direction to left
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Move left
            if (transform.position.x <= leftBound) // Check if the enemy has reached the left boundary
            {
                movingRight = true; // Change direction to right
                Flip();
            }
        }

    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Flip the enemy's scale on the x-axis
        transform.localScale = scaler; // Apply the new scale
    }
}
