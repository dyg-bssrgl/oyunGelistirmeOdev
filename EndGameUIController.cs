using UnityEngine;
using TMPro; // TextMeshPro i�in
using UnityEngine.SceneManagement;

public class EndGameUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Skor metni i�in TextMeshProUGUI
    public string mainMenuSceneName = "AnaMenu"; // Ana men� sahnenizin ad�
    public string gameSceneName = "Demo"; // Oyun sahnenizin ad�

    void Start()
    {
        // Kaydedilmi� skoru al ve g�ster
        int savedScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Score: " + savedScore;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
