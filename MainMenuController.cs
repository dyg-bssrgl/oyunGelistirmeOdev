using UnityEngine;
using TMPro; // TextMeshPro namespace'ini ekleyin
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public TMP_InputField maxZombiesInput; // TextMeshPro için TMP_InputField kullanýn
    public TMP_InputField totalZombiesInput; // TextMeshPro için TMP_InputField kullanýn

    void Start()
    {
        settingsPanel.SetActive(false);
        maxZombiesInput.text = "10";
        totalZombiesInput.text = "100";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Demo"); // Oyun sahnenizin adý
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SaveSettings()
    {
        int maxZombies = int.Parse(maxZombiesInput.text);
        int totalZombies = int.Parse(totalZombiesInput.text);

        PlayerPrefs.SetInt("MaxZombies", maxZombies);
        PlayerPrefs.SetInt("TotalZombies", totalZombies);

        CloseSettings();
    }
}
