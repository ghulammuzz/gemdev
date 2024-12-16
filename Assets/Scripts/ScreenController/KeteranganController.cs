using UnityEngine;
using UnityEngine.SceneManagement;

public class KeteranganController : MonoBehaviour
{
    public void Exit()
    {
        // Debug.Log("Button Home diklik!");
        SceneManager.LoadScene("MainMenu");
    }
    public void Police()
    {
        SceneManager.LoadScene("Police");
    }
    public void Student()
    {
        SceneManager.LoadScene("Student");
    }
    public void SpeedUp()
    {
        SceneManager.LoadScene("SpeedBoost");
    }
    public void Coin()
    {
        SceneManager.LoadScene("Coin");
    }


}
