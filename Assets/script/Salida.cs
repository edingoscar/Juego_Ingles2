using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida: MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            SceneManager.LoadScene("nivel1");
        }
    }
}
