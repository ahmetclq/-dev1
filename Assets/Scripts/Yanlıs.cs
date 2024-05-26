using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışan nesnenin etiketini kontrol et
        if (collision.gameObject.CompareTag("DogruCevap"))
        {
            // Dogru etiketine çarpıldığında
            Destroy(collision.gameObject); // Dogru kutuyu yok et
            Destroy(GameObject.FindGameObjectWithTag("Door1")); // Yanlis2 kutusunu yok et
        }
        else if (collision.gameObject.CompareTag("YanlısCevap") ||
                 collision.gameObject.CompareTag("YanlısCevap1") ||
                  collision.gameObject.CompareTag("YanlısCevap2"))
        {
            // Yanlis veya Yanlis1 etiketlerine çarpıldığında
            Destroy(collision.gameObject); // Çarpılan nesneyi yok et
        }
    }
}
