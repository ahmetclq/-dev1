using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Oyuncu2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışan nesnenin etiketini kontrol et
        if (collision.gameObject.CompareTag("DogruCevap21"))
        {
            // Dogru etiketine çarpıldığında
            Destroy(collision.gameObject); // Dogru kutuyu yok et
            Destroy(GameObject.FindGameObjectWithTag("Door2")); // Yanlis2 kutusunu yok et
        }
        else if (collision.gameObject.CompareTag("YanlısCevap21") ||
                 collision.gameObject.CompareTag("YanlısCevap22") ||
                  collision.gameObject.CompareTag("YanlısCevap23"))
        {
            // Yanlis veya Yanlis1 etiketlerine çarpıldığında
            Destroy(collision.gameObject); // Çarpılan nesneyi yok et
        }
    }
}
