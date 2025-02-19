using System;
using UnityEngine;

public class Salida: MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            GameManager.instance.win = true;
        }
    }
}
