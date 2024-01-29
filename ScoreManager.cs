using UnityEngine;
using TMPro; // TextMeshPro i�in bu namespace'i ekleyin

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI'deki skor texti (TextMeshPro kullan�larak)
    private int score = 0; // Ba�lang�� skoru

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("PlayerScore", score); // Skoru kaydet
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
