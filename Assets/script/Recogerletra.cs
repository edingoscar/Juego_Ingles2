using UnityEngine;

public class RecogerLetras : MonoBehaviour
{
    public GameObject letraActual;
    public float contador_tiempo = 0;
    public LanzarLetra lanzarLetra;

    void Update()
    {
        contador_tiempo += Time.deltaTime;

        //  Evitamos que la tecla E pueda soltar si ya lanzamos la letra
        if (Input.GetKeyDown(KeyCode.E) && contador_tiempo > 0.5 && letraActual != null)
        {
            print("Soltar letra");
            if (letraActual.transform.parent == transform)
            {
                letraActual.transform.SetParent(null);
                letraActual.transform.position = transform.position; 
                letraActual.gameObject.SetActive(true);
            }
            letraActual = null; // Eliminamos la referencia
            lanzarLetra.AsignarLetra(null); // Tambi�n avisamos a LanzarLetra

            contador_tiempo = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Solo podemos recoger una letra si realmente no tenemos ninguna
        if (Input.GetKey(KeyCode.E) && other.CompareTag("Letra") && contador_tiempo > 0.5 && letraActual == null)
        {
            print("Recoger letra");
            letraActual = other.gameObject;
            letraActual.transform.SetParent(transform);
            lanzarLetra.AsignarLetra(letraActual.transform);
            letraActual.gameObject.SetActive(false);
            contador_tiempo = 0;
        }
    }
}
