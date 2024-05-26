using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanTakip : MonoBehaviour
{
    public Transform hedef; // Takip edilecek hedef (genellikle Player)
    public float hareketHizi = 3f; // D��man�n hareket h�z�
    public float minMenzil = 2f; // D��man�n takip etmeye ba�layaca�� minimum mesafe
    public float maxMenzil = 10f; // D��man�n takibi b�rakaca�� maksimum mesafe

    void Update()
    {
        // Hedef yoksa veya mesafe belirtilen menzilin d���ndaysa, takibi durdur
        if (hedef == null || Vector3.Distance(transform.position, hedef.position) > maxMenzil)
        {
            return;
        }

        // Hedefe do�ru y�nelme
        transform.LookAt(hedef);

        // Hedefe do�ru hareket
        if (Vector3.Distance(transform.position, hedef.position) > minMenzil)
        {
            transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime);
        }
    }

    // D��man�n Player'a �arpmas� durumu
    private void OnCollisionEnter(Collision collision)
    {
        // �arp��ma durumunu kontrol et ve Player'a �arparsa
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player'�n CanKontrol bile�enine ula� ve can�n� azalt
            CanKontrol playerHealth = collision.gameObject.GetComponent<CanKontrol>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth(1);
            }

            // D��man� yok et
            Destroy(gameObject);
        }
    }
}
