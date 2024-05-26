using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışan nesnenin etiketini kontrol et
        if (collision.gameObject.CompareTag("DogruCevap31"))
        {
            // Dogru etiketine çarpıldığında
            Destroy(collision.gameObject); // Dogru kutuyu yok et
            Destroy(GameObject.FindGameObjectWithTag("Door3")); // Yanlis2 kutusunu yok et
        }
        else if (collision.gameObject.CompareTag("YanlısCevap31") ||
                 collision.gameObject.CompareTag("YanlısCevap32") ||
                  collision.gameObject.CompareTag("YanlısCevap33"))
        {
            // Yanlis veya Yanlis1 etiketlerine çarpıldığında
            Destroy(collision.gameObject); // Çarpılan nesneyi yok et
        }
    }
}
