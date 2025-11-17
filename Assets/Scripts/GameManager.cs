using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score++;
        UIManager.Instance.UpdateScore(score);
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
