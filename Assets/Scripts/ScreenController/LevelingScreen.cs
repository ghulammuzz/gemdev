using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelingScreen : MonoBehaviour
{
    public void LevelEasy()
    {
        SceneManager.LoadScene("EasyGameScene");
    }

    public void LevelMedium()
    {
        SceneManager.LoadScene("MediumGameScene");
    }

    public void LevelHard()
    {
        SceneManager.LoadScene("HardGameScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}


