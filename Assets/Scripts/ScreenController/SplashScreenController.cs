using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public float splashDuration = 3.0f;

    void Start()
    {
        Invoke("LoadMainMenu", splashDuration);
    }

    void LoadMainMenu()
    {
        // remove all saved local storage
        PlayerPrefs.DeleteAll();
        int levelEasyCompleted = PlayerPrefs.GetInt("LevelEasyCompleted");
        Debug.Log("level easy completed: " + levelEasyCompleted);
        SceneManager.LoadScene("MainMenu");

    }
}

