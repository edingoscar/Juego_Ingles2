using UnityEngine;

public class LetraDetector : MonoBehaviour
{
    public LanzarLetra lanzarLetra;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            
            lanzarLetra.DetenerMovimiento(); 
        }
    }
}

