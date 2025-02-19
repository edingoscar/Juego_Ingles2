using UnityEngine;

public class Letra : MonoBehaviour
{
    public float fuerzaLanzamiento;
    private Vector3 posicionObjetivo;
    public Casilla casilla;
    public bool enMovimiento = false; 

    void Update()
    {
        if (enMovimiento)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(posicionObjetivo.x, posicionObjetivo.y, transform.position.z), fuerzaLanzamiento * Time.deltaTime);

            // Si la letra ya llego al objetivo, detener el movimiento
            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
            {
                DetenerMovimiento();
            }
        }
    }

    public void IniciarMovimiento(float fuerzaLanzamiento, Vector3 posicionObjetivo){
        this.fuerzaLanzamiento = fuerzaLanzamiento;
        this.posicionObjetivo = posicionObjetivo;
        enMovimiento = true;
    }

    public void DetenerMovimiento()
    {
        enMovimiento = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            DetenerMovimiento(); 
        }
    }
}


