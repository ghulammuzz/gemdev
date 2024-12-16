using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Kecepatan gerak karakter
    public float speed = 5f;

    void Update()
    {
        // Ambil input dari keyboard
        float horizontalInput = Input.GetAxis("Horizontal"); // Kiri (-1) dan kanan (+1)
        float verticalInput = Input.GetAxis("Vertical");     // Bawah (-1) dan atas (+1)

        // Hitung arah gerak
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f);

        // Gerakkan karakter
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
