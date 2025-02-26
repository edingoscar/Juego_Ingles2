using UnityEngine;

public class RecogerLetras : MonoBehaviour
{
    public Letra letraActual = null;
    private Letra letraEnZona = null;
    public float contador_tiempo = 0;

    public AudioClip AgarrarSound;
    public AudioClip SoltarSound;

    void Update()
    {
        if(contador_tiempo < 1){
            contador_tiempo += Time.deltaTime;
        }

        //  Evitamos que la tecla E pueda soltar si ya lanzamos la letra
        if (Input.GetKeyDown(KeyCode.E) && contador_tiempo > 0.5 && letraActual != null)
        {
            print("Soltar letra");
            if (letraActual.transform.parent == transform)
            {
                letraActual.transform.SetParent(null);
                letraActual.transform.position = transform.position; 
                letraActual.GetComponent<SpriteRenderer>().sortingOrder = 0;
                SoundFXManager.instance.PlaySoundFXClip(SoltarSound, transform, 1f);
            }
            letraActual = null; // Eliminamos la referencia

            contador_tiempo = 0;
        }

        if(letraActual != null){
            letraActual.transform.position = new Vector3(transform.position.x,transform.position.y + 0.4f, letraActual.transform.position.z);
        }

        if (Input.GetKey(KeyCode.E) && letraEnZona != null && contador_tiempo > 0.5 && letraActual == null)
        {
            print("Recoger letra");
            letraActual = letraEnZona;
            letraActual.transform.SetParent(transform);
            letraActual.GetComponent<SpriteRenderer>().sortingOrder = 2;
            SoundFXManager.instance.PlaySoundFXClip(AgarrarSound, transform, 1f);
            contador_tiempo = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Letra"))
        {
            letraEnZona = other.gameObject.GetComponent<Letra>();
        }
    }
}
