using UnityEngine;

public class RecogerLetras : MonoBehaviour
{
    public GameObject letraActual;
    public float contador_tiempo = 0;
    public LanzarLetra lanzarLetra;
    public LayerMask letraLayer;
    public Transform deteccionPunto;
    public float radioDeteccion = 0.5f;


    void Update()
    {
        contador_tiempo += Time.deltaTime;
        Collider2D letraDetectada = Physics2D.OverlapCircle(deteccionPunto.position, radioDeteccion, letraLayer);
        //  Evitamos que la tecla E pueda soltar si ya lanzamos la letra
        if (Input.GetKeyDown(KeyCode.E) && letraDetectada != null && contador_tiempo > 0.5f && letraActual == null)
        {
            print("Recoger letra");
            letraActual = letraDetectada.gameObject;
            letraActual.transform.SetParent(transform);
            letraActual.GetComponent<SpriteRenderer>().sortingOrder = 2;
            lanzarLetra.AsignarLetra(letraActual.transform);
            contador_tiempo = 0;
        }

        // Soltar la letra
        if (Input.GetKeyDown(KeyCode.E) && contador_tiempo > 0.5 && letraActual != null)
        {
            print("Soltar letra");
            letraActual.transform.SetParent(null);
            letraActual.transform.position = transform.position;
            letraActual.GetComponent<SpriteRenderer>().sortingOrder = 0;
            letraActual = null;
            lanzarLetra.AsignarLetra(null);
            contador_tiempo = 0;
        }

        if (letraActual != null)
        {
            letraActual.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, letraActual.transform.position.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el radio de detección en la escena para depuración
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(deteccionPunto.position, radioDeteccion);
    }
}
