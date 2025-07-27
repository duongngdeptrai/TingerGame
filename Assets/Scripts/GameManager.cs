using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; // UI Text to display the score
    [SerializeField] private GameObject gameOverUI; // Reference to the GameOver UI
    [SerializeField] private GameObject gameWinUI; // Reference to the GameWin UI (if needed)
    private bool isGameOver = false; // Flag to check if the game is over
    private bool isGameWin = false; // Flag to check if the game is won (if needed)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(); // Initialize the score display
        gameOverUI.SetActive(false); // Hide the GameOver UI at the start
        gameWinUI.SetActive(false); // Hide the GameWin UI at the start (if needed)
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddScore(int points)
    {
        if (isGameOver) return; // If the game is over, do not add score
        if (isGameWin) return; // If the game is won, do not add score
        score += points;
        UpdateScore(); // Update the score display
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString(); // Update the score text in the UI
    }
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true; // Set the game over flag
        score = 0; // Reset the score
        Time.timeScale = 0; // Pause the game
        gameOverUI.SetActive(true); // Show the GameOver UI
    }
    public void GameWin()
    {
        isGameWin = true; // Set the game win flag (if needed)
        score = 0; // Reset the score
        Time.timeScale = 0; // Pause the game
        gameWinUI.SetActive(true); // Show the GameWin UI (if needed)
    }
    public void RestartGame()
    {
        isGameOver = false; // Reset the game over flag
        score = 0; // Reset the score
        UpdateScore(); // Update the score display
        Time.timeScale = 1; // Resume the game
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name); // Reload the current scene to restart the game
    }
    public bool IsGameOver()
    {
        return isGameOver; // Return the game over status
    }
    public bool IsGameWin()
    {
        return isGameWin; // Return the game win status (if needed)   
    }
    public int HowManyCoins()
    {
        return score; // Return the current score (number of coins collected)
    }
}
