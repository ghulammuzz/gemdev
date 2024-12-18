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
        SceneManager.LoadScene("Student");
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
}


