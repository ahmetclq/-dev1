using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanKontrol : MonoBehaviour
{
    public int can = 3; // Karakterin can deðeri
    public GameObject gameOverPanel; // Oyun bittiðinde görünecek panel
    public GameObject winPanel; // Oyun kazanýldýðýnda görünecek panel

    // Çarpýþma durumunu kontrol eden metod
    private void OnCollisionEnter(Collision collision)
    {
        // Eðer çarpýþma YanlýsCevap tag'ine sahip bir objeyle gerçekleþtiyse
        if (collision.gameObject.CompareTag("YanlýsCevap") ||
            collision.gameObject.CompareTag("YanlýsCevap1") ||
            collision.gameObject.CompareTag("YanlýsCevap2") ||
            collision.gameObject.CompareTag("YanlýsCevap21") ||
            collision.gameObject.CompareTag("YanlýsCevap22") ||
            collision.gameObject.CompareTag("YanlýsCevap23") ||
            collision.gameObject.CompareTag("YanlýsCevap31") ||
            collision.gameObject.CompareTag("YanlýsCevap32") ||
            collision.gameObject.CompareTag("YanlýsCevap33"))
        {
            // Düþmanýn verdiði hasarý "DecreaseHealth" metoduna iletiyoruz
            DecreaseHealth(1);
            // Çarpýþýlan nesneyi yok et (YanlýsCevap tag'ine sahip nesne)
            Destroy(collision.gameObject);
        }
        // Eðer çarpýþma FinalD1, FinalY1, FinalY2 veya FinalY3 tag'ine sahip bir objeyle gerçekleþtiyse
        else if (collision.gameObject.CompareTag("FinalD1") ||
                 collision.gameObject.CompareTag("FinalY1") ||
                 collision.gameObject.CompareTag("FinalY2") ||
                 collision.gameObject.CompareTag("FinalY3"))
        {
            // Eðer çarpýþma FinalD1 tag'ine sahip bir objeyle gerçekleþtiyse
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
                // Kazanma tag'ine sahip olmayan diðer kutulara çarpýldýðýnda can azalt
                DecreaseHealth(1);
                // Çarpýþýlan nesneyi yok et (FinalY1, FinalY2 veya FinalY3 tag'ine sahip nesne)
                Destroy(collision.gameObject);
            }
        }
        // Eðer çarpýþma Health tag'ine sahip bir objeyle gerçekleþtiyse
        else if (collision.gameObject.CompareTag("Health"))
        {
            // Caný arttýr ve çarpýþýlan nesneyi yok et (Health tag'ine sahip nesne)
            can++;
            Destroy(collision.gameObject);
        }
    }

    // Caný azaltan metod
    public void DecreaseHealth(int damage)
    {
        can -= damage; // Verilen hasarý can deðerinden çýkar
        if (can <= 0)
        {
            // Eðer can 0 veya daha azsa, oyunu durdur
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
