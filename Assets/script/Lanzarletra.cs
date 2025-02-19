using UnityEngine;

public class LanzarLetra : MonoBehaviour
{
    public float fuerzaLanzamiento = 10f;
    private Transform letraActual;
    private Vector3 posicionObjetivo;
    public RecogerLetras recogerLetras;
    private bool enMovimiento = false; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && letraActual != null)
        {
            print("Lanzar letra");
            letraActual.SetParent(null);
            letraActual.GetComponent<SpriteRenderer>().sortingOrder = 0;
            letraActual.transform.position = transform.position; 
            //letraActual.gameObject.SetActive(true);

            
            posicionObjetivo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionObjetivo.z = 0; 

            enMovimiento = true; 

            recogerLetras.letraActual = null; // Quitamos la referencia en el otro script
        }

        // Si hay una letra en movimiento, moverla hasta la posici�n objetivo
        if (enMovimiento && letraActual != null)
        {
            letraActual.position = Vector3.MoveTowards(letraActual.position, posicionObjetivo, fuerzaLanzamiento * Time.deltaTime);

            // Si la letra ya lleg� al objetivo, detener el movimiento
            if (Vector3.Distance(letraActual.position, posicionObjetivo) < 0.1f)
            {
                DetenerMovimiento();
            }
        }
    }

    public void AsignarLetra(Transform letra)
    {
        letraActual = letra;
        enMovimiento = false; 
    }

    public void DetenerMovimiento()
    {
        enMovimiento = false;
        letraActual = null; 
    }

}


