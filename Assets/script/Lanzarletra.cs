using UnityEngine;

public class LanzarLetra : MonoBehaviour
{
    public float fuerzaLanzamiento = 10f;
    public RecogerLetras recogerLetras;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && recogerLetras.letraActual != null)
        {
            print("Lanzar letra");
            recogerLetras.letraActual.transform.SetParent(null);
            recogerLetras.letraActual.GetComponent<SpriteRenderer>().sortingOrder = 0;
            recogerLetras.letraActual.transform.position = transform.position; 
            //letraActual.gameObject.SetActive(true);

            
            recogerLetras.letraActual.IniciarMovimiento(fuerzaLanzamiento, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            recogerLetras.letraActual = null;
        }
    }
}


