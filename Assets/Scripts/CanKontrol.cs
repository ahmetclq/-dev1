using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanKontrol : MonoBehaviour
{
    public int can = 3; // Karakterin can de�eri
    public GameObject gameOverPanel; // Oyun bitti�inde g�r�necek panel
    public GameObject winPanel; // Oyun kazan�ld���nda g�r�necek panel

    // �arp��ma durumunu kontrol eden metod
    private void OnCollisionEnter(Collision collision)
    {
        // E�er �arp��ma Yanl�sCevap tag'ine sahip bir objeyle ger�ekle�tiyse
        if (collision.gameObject.CompareTag("Yanl�sCevap") ||
            collision.gameObject.CompareTag("Yanl�sCevap1") ||
            collision.gameObject.CompareTag("Yanl�sCevap2") ||
            collision.gameObject.CompareTag("Yanl�sCevap21") ||
            collision.gameObject.CompareTag("Yanl�sCevap22") ||
            collision.gameObject.CompareTag("Yanl�sCevap23") ||
            collision.gameObject.CompareTag("Yanl�sCevap31") ||
            collision.gameObject.CompareTag("Yanl�sCevap32") ||
            collision.gameObject.CompareTag("Yanl�sCevap33"))
        {
            // D��man�n verdi�i hasar� "DecreaseHealth" metoduna iletiyoruz
            DecreaseHealth(1);
            // �arp���lan nesneyi yok et (Yanl�sCevap tag'ine sahip nesne)
            Destroy(collision.gameObject);
        }
        // E�er �arp��ma FinalD1, FinalY1, FinalY2 veya FinalY3 tag'ine sahip bir objeyle ger�ekle�tiyse
        else if (collision.gameObject.CompareTag("FinalD1") ||
                 collision.gameObject.CompareTag("FinalY1") ||
                 collision.gameObject.CompareTag("FinalY2") ||
                 collision.gameObject.CompareTag("FinalY3"))
        {
            // E�er �arp��ma FinalD1 tag'ine sahip bir objeyle ger�ekle�tiyse
            if (collision.gameObject.CompareTag("FinalD1"))
            {
                SceneManager.LoadScene("Win");
                // Oyunu durdur ve Kazanma panelini aktif et
                Time.timeScale = 0;
                if (winPanel != null)
                {
                    
                    winPanel.SetActive(true);
                }
            }
            else
            {
                // Kazanma tag'ine sahip olmayan di�er kutulara �arp�ld���nda can azalt
                DecreaseHealth(1);
                // �arp���lan nesneyi yok et (FinalY1, FinalY2 veya FinalY3 tag'ine sahip nesne)
                Destroy(collision.gameObject);
            }
        }
        // E�er �arp��ma Health tag'ine sahip bir objeyle ger�ekle�tiyse
        else if (collision.gameObject.CompareTag("Health"))
        {
            // Can� artt�r ve �arp���lan nesneyi yok et (Health tag'ine sahip nesne)
            can++;
            Destroy(collision.gameObject);
        }
    }

    // Can� azaltan metod
    public void DecreaseHealth(int damage)
    {
        can -= damage; // Verilen hasar� can de�erinden ��kar
        if (can <= 0)
        {
            // E�er can 0 veya daha azsa, oyunu durdur
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
            // Game Over panelini aktif et
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
