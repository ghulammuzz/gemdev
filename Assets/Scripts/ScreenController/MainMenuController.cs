using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour


{


    public void StartGame()
    {

        SceneManager.LoadScene("LevelSelection");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Keterangan()
    {
        SceneManager.LoadScene("Police");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseGame()
    {
        Debug.Log("Play Mode dihentikan!");
        Application.Quit();
    }

    public void reset(){
        PlayerPrefs.DeleteAll();
        int levelEasyCompleted = PlayerPrefs.GetInt("LevelEasyCompleted");
        Debug.Log("level easy completed: " + levelEasyCompleted);
        SceneManager.LoadScene("MainMenu");
    }
}


