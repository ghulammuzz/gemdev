using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelingScreen : MonoBehaviour
{
    void Start()
    {
        // Pastikan nilai awal PlayerPrefs sudah diset
        if (!PlayerPrefs.HasKey("LevelEasyCompleted")) PlayerPrefs.SetInt("LevelEasyCompleted", 0);
        if (!PlayerPrefs.HasKey("LevelMediumCompleted")) PlayerPrefs.SetInt("LevelMediumCompleted", 0);
        if (!PlayerPrefs.HasKey("LevelHardCompleted")) PlayerPrefs.SetInt("LevelHardCompleted", 0);

        PlayerPrefs.Save(); // Simpan jika belum ada
    }

    public void LevelEasy()
    {
        // Akses level Easy langsung dibuka
        SceneManager.LoadScene("EasyGameScene");
    }

    public void LevelMedium()
    {
        int levelEasyCompleted = PlayerPrefs.GetInt("LevelEasyCompleted");
        Debug.Log("level easy completed: " + levelEasyCompleted);
        // Periksa apakah level Easy sudah selesai
        if (PlayerPrefs.GetInt("LevelEasyCompleted") == 1)
        {
            SceneManager.LoadScene("MediumGameScene");
        }
        else
        {
            Debug.Log("Anda harus menyelesaikan Level Easy terlebih dahulu!");
        }
    }

    public void LevelHard()
    {
        int levelMediumCompleted = PlayerPrefs.GetInt("LevelMediumCompleted");
        Debug.Log("level medium completed: " + levelMediumCompleted);
        // Periksa apakah level Medium sudah selesai
        if (PlayerPrefs.GetInt("LevelMediumCompleted") == 1)
        {
            SceneManager.LoadScene("HardGameScene");
        }
        else
        {
            Debug.Log("Anda harus menyelesaikan Level Medium terlebih dahulu!");
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
