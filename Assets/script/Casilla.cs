using TMPro;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    private GameObject player;
    public bool active = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    void Update()
    {
        //Cambiar el color del texto dependiendo de si esta activo
        if(active){
            GetComponent<TMP_Text>().color = new Color(1, 0.9f, 0.1f,1);
        }else{
            GetComponent<TMP_Text>().color = new Color(1,1,1,0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Letra"))
        {
            //Si la letra correcta esta colisionando entonces la casilla se activa
            if(player.GetComponent<RecogerLetras>().letraActual != collision.GetComponent<Letra>()){
                if(collision.name == GetComponent<TMP_Text>().text && !collision.GetComponent<Letra>().enMovimiento &&(collision.GetComponent<Letra>().casilla == null || collision.GetComponent<Letra>().casilla == this)){
                    collision.GetComponent<Letra>().casilla = this;
                    active = true;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Letra"))
        {
            //Si la letra correcta esta colisionando entonces la casilla se activa, si se levanta se desactiva
            if(player.GetComponent<RecogerLetras>().letraActual != collision.GetComponent<Letra>()){
                if(collision.name == GetComponent<TMP_Text>().text && !collision.GetComponent<Letra>().enMovimiento &&(collision.GetComponent<Letra>().casilla == null || collision.GetComponent<Letra>().casilla == this)){
                    collision.GetComponent<Letra>().casilla = this;
                    active = true;
                }
            }else{
                if(collision.name == GetComponent<TMP_Text>().text && collision.GetComponent<Letra>().casilla == this){
                    collision.GetComponent<Letra>().casilla = null;
                    active = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Letra"))
        {
            //Si la letra sale del area la casilla se desactiva
            if(collision.name == GetComponent<TMP_Text>().text && collision.GetComponent<Letra>().casilla == this){
                collision.GetComponent<Letra>().casilla = null;
                active = false;
            }
        }
    }
}


