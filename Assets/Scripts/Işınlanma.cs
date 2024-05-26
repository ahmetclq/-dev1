using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform startingPoint; // Başlangıç noktası

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Eğer çarpışan nesne "Player" etiketine sahipse
        {
            collision.gameObject.transform.position = startingPoint.position; // Oyuncuyu başlangıç noktasına ışınlama
        }
    }
}
