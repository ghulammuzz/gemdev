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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Set darah awal
        UpdateHealthText();

        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
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
            collectibleText.text = "Items: " + totalCollectibles;
        }
    }

    private void ShowFinishPanel()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(true);
        }
        if (finishMessageText != null)
        {
            finishMessageText.text = "Selamat Anda Menyelesaikan Level Easy!\nTotal Items: " + totalCollectibles;
        }
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

