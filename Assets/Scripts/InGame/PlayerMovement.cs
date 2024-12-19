using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject finishPanel;
    public Text collectibleText;
    public Text finishMessageText;
    public Text healthText; // UI untuk menampilkan darah
    public int maxHealth = 3; // Darah awal pemain

    private Rigidbody2D rb;
    private Vector2 movement;
    private int totalCollectibles = 0;
    private int currentHealth;
    private bool isSpeedBoosted = false;

    private int targetCollectibles; // Jumlah koin yang harus dikumpulkan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Set darah awal
        UpdateHealthText();

        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
        }

        // Tentukan target collectible berdasarkan nama level
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "EasyGameScene")
        {
            targetCollectibles = 10;
        }
        else if (currentScene == "MediumGameScene")
        {
            targetCollectibles = 15;
        }
        else if (currentScene == "HardGameScene")
        {
            targetCollectibles = 20;
        }

        UpdateCollectibleText();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Kurangi darah
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("MainMenu"); // Kembali ke menu utama
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            ShowFinishPanel();
        }
        else if (other.gameObject.CompareTag("Collectibles"))
        {
            CollectItem(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Speeds"))
        {
            SpeedBoost(other.gameObject);
        }
    }

    private void CollectItem(GameObject collectible)
    {
        totalCollectibles++;
        Destroy(collectible);
        UpdateCollectibleText();
    }

    private void UpdateCollectibleText()
    {
        if (collectibleText != null)
        {
            collectibleText.text = "Items: " + totalCollectibles + "/" + targetCollectibles;
        }
    }

    private void ShowFinishPanel()
    {
        // Cek apakah semua collectible telah dikumpulkan
        if (totalCollectibles >= targetCollectibles)
        {
            if (finishPanel != null)
            {
                finishPanel.SetActive(true);
            }
            if (finishMessageText != null)
            {
                finishMessageText.text = "Selamat Anda Menyelesaikan Level Ini!\nTotal Items: " + totalCollectibles;
            }

            // Menyimpan progres level
            SaveLevelProgress();

            Time.timeScale = 0f; // Pause permainan
        }
        else
        {
            Debug.Log("Anda belum mengumpulkan semua koin!");
        }
    }

    private void SaveLevelProgress()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "EasyGameScene")
        {
            PlayerPrefs.SetInt("LevelEasyCompleted", 1);
        }
        else if (currentScene == "MediumGameScene")
        {
            PlayerPrefs.SetInt("LevelMediumCompleted", 1);
        }
        else if (currentScene == "HardGameScene")
        {
            PlayerPrefs.SetInt("LevelHardCompleted", 1);
        }

        PlayerPrefs.Save(); // Simpan perubahan ke PlayerPrefs
        Debug.Log("Progres Level Disimpan!");
    }

    private void SpeedBoost(GameObject speedObject)
    {
        Destroy(speedObject); // Hancurkan objek Speeds
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    private System.Collections.IEnumerator SpeedBoostCoroutine()
    {
        isSpeedBoosted = true;
        moveSpeed *= 2; // Gandakan kecepatan
        yield return new WaitForSeconds(3); // Tunggu selama 3 detik
        moveSpeed /= 2; // Kembalikan kecepatan ke normal
        isSpeedBoosted = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
