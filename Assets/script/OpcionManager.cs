using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionManager : MonoBehaviour
{

    public Toggle toggle;
    public Slider sliderVolumen;
    public TMP_Dropdown dropdownResolucion;

    private Resolution[] resoluciones;

    void Awake()
    {
        resoluciones = Screen.resolutions;
    }

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        sliderVolumen.onValueChanged.RemoveAllListeners();
        dropdownResolucion.onValueChanged.RemoveAllListeners();

        sliderVolumen.value = PlayerPrefs.GetFloat("Volumen", 50f);
        //resolucion
        dropdownResolucion.ClearOptions();

        List<string> opciones = new List<string>();
        int indiceResolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            if (!opciones.Contains(opcion))
            {
                opciones.Add(opcion);
            }


            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                indiceResolucionActual = i;
            }
        }

        dropdownResolucion.AddOptions(opciones);
        dropdownResolucion.value = PlayerPrefs.GetInt("Resolucion", indiceResolucionActual); ;
        dropdownResolucion.RefreshShownValue();

        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        dropdownResolucion.onValueChanged.AddListener(CambiarResolucion);
    }


    void Update()
    {

    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    private void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
        PlayerPrefs.SetFloat("Volumen", valor);
    }

    private void CambiarResolucion(int indice)
    {
        Resolution seleccionada = resoluciones[indice];
        Screen.SetResolution(seleccionada.width, seleccionada.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolucion", indice);
    }
}
