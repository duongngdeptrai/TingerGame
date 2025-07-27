using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] private float jumpForce = 18f; // Force applied when jumping
    [SerializeField] private LayerMask groundLayer; // Layer mask to identify ground objects
    [SerializeField] private Transform groundCheck; // Transform to check if the player is grounded
    private Animator animator; // Reference to the Animator component
    bool isGrounded; // Flag to check if the player is on the ground
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private GameManager gameManager; // Reference to the GameManager script
    private AudioManager audioManager; // Reference to the AudioManager script
    private Vector3 spawnPoint;
    private void Awake()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        gameManager = FindAnyObjectByType<GameManager>(); // Find the GameManager in the scene
        audioManager = FindAnyObjectByType<AudioManager>(); // Find the AudioManager in the scene
    }
    void Start()
    {
        spawnPoint = transform.position; // Save the initial spawn point
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsGameWin()) return; // If the game is over, skip player input handling
        HandleMovement();
        HandleJump();
        UpdateAnimation();
        outMap(); // Check if the player is out of the map
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1); // Face right
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1); // Face left
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioManager.PlayJumpSound(); // Play jump sound
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded && rb.linearVelocity.y > 0.1f;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
    public void outMap()
    {
        if (transform.position.y < -20f) // Check if the player falls below a certain height
        {
            transform.position = spawnPoint; // Reset player position to spawn point
            gameManager.GameOver(); // Call GameOver method in GameManager
        }
    }
}
