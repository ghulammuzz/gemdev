using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referensi ke panel pause
    private bool isPaused = false;

    void Start()
    {
        // Nonaktifkan panel pause di awal permainan
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        // Periksa input untuk pause (tombol P)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Sembunyikan panel pause
        }
        Time.timeScale = 1f; // Lanjutkan waktu
        isPaused = false;
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Tampilkan panel pause
        }
        Time.timeScale = 0f; // Hentikan waktu
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal
        SceneManager.LoadScene("MainMenu");
    }
}

