using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public float rotationSpeed = 100f; // Yatay d�n�� h�z�
    public float lookSpeed = 500f; // Dikey bak�� h�z�

    private float rotation = 0f;
    private float look = 0f;

    void Update()
    {
        // Klavyeden giri�i al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket ve d�nme i�levi
        MovePlayer(horizontalInput, verticalInput);

        // Fare ile dikey bak��� kontrol etme
        LookUpDown();

    }

    void MovePlayer(float horizontal, float vertical)
    {
        // Hareket vekt�r�n� hesapla ve uygula
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Yatay d�n��� hesapla ve uygula
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }

    void LookUpDown()
    {
        // Fare hareketini al
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        // Dikey bak��� kontrol et
        look -= mouseY;
        look = Mathf.Clamp(look, -90f, 90f); // A��r� d�nme �nleme

        // Karakterin dikey d�n���n� ayarla
        transform.GetChild(0).localRotation = Quaternion.Euler(look, 0f, 0f);
    }
}
