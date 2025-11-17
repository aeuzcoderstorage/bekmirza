using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public Button restartButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        scoreText.text = "0";
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOver(int finalScore)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Your Score: " + finalScore;
        restartButton.onClick.AddListener(() =>
        {
            GameManager.Instance.RestartGame();
        });
    }
}
