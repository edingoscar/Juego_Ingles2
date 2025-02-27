using TMPro;
using UnityEngine;

public class PuzzlePalabra : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool palabraCompleta = true;
        foreach (Transform childTransform in this.transform)
        {
            if(childTransform.CompareTag("Palabra")){
                foreach (Transform casilla in childTransform)
                {
                    if(!casilla.GetComponent<Casilla>().active) palabraCompleta = false;
                }
                if(palabraCompleta) childTransform.gameObject.SetActive(false);
            }
            if(childTransform.CompareTag("Item")){
                if (palabraCompleta) 
                {
                    childTransform.gameObject.SetActive(true);
                    GameManager.instance.setcontador(1);                   
                    GameManager.instance.Palabra1 = true;
                    GameManager.instance.Mision.color = Color.green;
                    palabraCompleta = false;
                }
               
            }
        }
    }
}
