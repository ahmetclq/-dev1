using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float rotationSpeed = 100f; // Yatay dönüþ hýzý
    public float lookSpeed = 500f; // Dikey bakýþ hýzý

    private float rotation = 0f;
    private float look = 0f;

    void Update()
    {
        // Klavyeden giriþi al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket ve dönme iþlevi
        MovePlayer(horizontalInput, verticalInput);

        // Fare ile dikey bakýþý kontrol etme
        LookUpDown();

    }

    void MovePlayer(float horizontal, float vertical)
    {
        // Hareket vektörünü hesapla ve uygula
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Yatay dönüþü hesapla ve uygula
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }

    void LookUpDown()
    {
        // Fare hareketini al
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        // Dikey bakýþý kontrol et
        look -= mouseY;
        look = Mathf.Clamp(look, -90f, 90f); // Aþýrý dönme önleme

        // Karakterin dikey dönüþünü ayarla
        transform.GetChild(0).localRotation = Quaternion.Euler(look, 0f, 0f);
    }
}
