using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager script
    private AudioManager audioManager; // Reference to the AudioManager script
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>(); // Find the GameManager in the scene
        audioManager = FindAnyObjectByType<AudioManager>(); // Find the AudioManager in the scene
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // Destroy the coin object
            audioManager.PlayCoinSound(); // Play coin collection sound
            gameManager.AddScore(1); // Add score when the player collects a coin
        }
        if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver(); // Call GameOver method in GameManager when the player collides with a trap
        }
        if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver(); // Call GameOver method in GameManager when the player collides with a enemy    
        }
        if (collision.CompareTag("Key"))
        {
            if (gameManager.HowManyCoins() == 20)
            {
                gameManager.GameWin(); // Call GameWin method in GameManager when the player collects the key after collecting all coins
            }
        }
    }
}
