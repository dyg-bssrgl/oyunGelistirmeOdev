using UnityEngine;
using TMPro; // TextMeshPro için
using UnityEngine.SceneManagement;

public class EndGameUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Skor metni için TextMeshProUGUI
    public string mainMenuSceneName = "AnaMenu"; // Ana menü sahnenizin adý
    public string gameSceneName = "Demo"; // Oyun sahnenizin adý

    void Start()
    {
        // Kaydedilmiþ skoru al ve göster
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
