using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanTakip : MonoBehaviour
{
    public Transform hedef; // Takip edilecek hedef (genellikle Player)
    public float hareketHizi = 3f; // Düþmanýn hareket hýzý
    public float minMenzil = 2f; // Düþmanýn takip etmeye baþlayacaðý minimum mesafe
    public float maxMenzil = 10f; // Düþmanýn takibi býrakacaðý maksimum mesafe

    void Update()
    {
        // Hedef yoksa veya mesafe belirtilen menzilin dýþýndaysa, takibi durdur
        if (hedef == null || Vector3.Distance(transform.position, hedef.position) > maxMenzil)
        {
            return;
        }

        // Hedefe doðru yönelme
        transform.LookAt(hedef);

        // Hedefe doðru hareket
        if (Vector3.Distance(transform.position, hedef.position) > minMenzil)
        {
            transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime);
        }
    }

    // Düþmanýn Player'a çarpmasý durumu
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma durumunu kontrol et ve Player'a çarparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player'ýn CanKontrol bileþenine ulaþ ve canýný azalt
            CanKontrol playerHealth = collision.gameObject.GetComponent<CanKontrol>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth(1);
            }

            // Düþmaný yok et
            Destroy(gameObject);
        }
    }
}
