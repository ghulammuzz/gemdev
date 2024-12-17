using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public Transform player; 
    public float chaseSpeed = 2f; 
    public float attackRadius = 10f; 
    public float attackRangeRadius = 3f; 
    public int damage = 1; 
    private bool isAttacking = false; 

    private Rigidbody2D rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Debug.Log("Jarak ke pemain: " + distanceToPlayer); 

        if (distanceToPlayer <= attackRadius)
        {
            Debug.Log("Musuh mengejar pemain!"); 
            ChasePlayer();

          
            if (distanceToPlayer <= attackRangeRadius && !isAttacking)
            {
                Debug.Log("Musuh menyerang!"); 
                AttackPlayer();
            }
        }
    }

    private void ChasePlayer()
    {
        
        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * chaseSpeed * Time.deltaTime;

        
        rb.MovePosition(newPosition);
    }

    private void AttackPlayer()
    {
        isAttacking = true; 
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        if (playerScript != null)
        {
            playerScript.TakeDamage(damage); 
        }
        Invoke("ResetAttack", 1f); 
    }

    private void ResetAttack()
    {
        isAttacking = false; 
    }
}