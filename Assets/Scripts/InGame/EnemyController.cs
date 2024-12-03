using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float chaseSpeed = 2f; // Kecepatan musuh mengejar pemain
    public float attackRadius = 10f; // Radius serangan
    public int damage = 1; // Damage yang diberikan musuh
    private bool isAttacking = false; // Menyimpan status serangan

    private void Update()
	{
	    if (player == null)
		return;

	    float distanceToPlayer = Vector2.Distance(transform.position, player.position);

	    Debug.Log("Jarak ke pemain: " + distanceToPlayer); // Debugging jarak

	    if (distanceToPlayer <= attackRadius)
	    {
		Debug.Log("Musuh mengejar pemain!"); // Debugging pengejaran
		ChasePlayer();

		if (distanceToPlayer <= 0.5f && !isAttacking)
		{
		    Debug.Log("Musuh menyerang!"); // Debugging serangan
		    AttackPlayer();
		}
	    }
	}


    private void ChasePlayer()
    {
        // Gerakkan musuh ke arah pemain
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        isAttacking = true; // Set status menyerang
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        if (playerScript != null)
        {
            playerScript.TakeDamage(damage); // Kurangi darah pemain
        }
        Invoke("ResetAttack", 1f); // Reset serangan setelah 1 detik
    }

    private void ResetAttack()
    {
        isAttacking = false; // Izinkan serangan lagi
    }
}

