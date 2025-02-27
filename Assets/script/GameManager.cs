using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public static int level;
    public bool canPause = true;
    // Para que suba los numeros de palabras encontradas
    public TMP_Text progreso;
    private int ContadorProgreso = 0;
    public int LimiteProgreso;

    // Cuadros de significados
    public bool Palabra1;
    public GameObject significado1;
    public float contadorCuadro = 0;

    public TMP_Text Mision;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canPause = true;
        Palabra1 = false;
    }

    // Update is called once per frame
    void Update()
    {

            if(Input.GetKeyDown(KeyCode.Escape) && canPause){
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if(pauseMenu.activeSelf){
                    Time.timeScale = 0f;
                }else{
                    Time.timeScale = 1f;
                }
            }

        if (Palabra1)
        {
            significado1.SetActive(true);
            contadorCuadro += Time.deltaTime;
            if (contadorCuadro >= 2)  
            {
                Palabra1 = false;
                significado1.SetActive(false);
                contadorCuadro = 0; 
            }
        }


        progreso.text = ContadorProgreso + "/" + LimiteProgreso;
    }

    public void BtnResume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BtnMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void BtnReset(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void setcontador(int valor)
    {
        ContadorProgreso += valor;
    }
}
