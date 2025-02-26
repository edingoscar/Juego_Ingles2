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
        // Cargar configuración guardada
        bool pantallaCompleta = PlayerPrefs.GetInt("PantallaCompleta", 1) == 1; // Por defecto, true (1)
        Screen.fullScreenMode = pantallaCompleta ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.fullScreen = pantallaCompleta;
        toggle.isOn = pantallaCompleta;

        sliderVolumen.onValueChanged.RemoveAllListeners();
        dropdownResolucion.onValueChanged.RemoveAllListeners();

        sliderVolumen.value = PlayerPrefs.GetFloat("Volumen", 50f);

        // Configurar resoluciones
        dropdownResolucion.ClearOptions();
        List<string> opciones = new List<string>();
        int indiceResolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
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
        dropdownResolucion.value = PlayerPrefs.GetInt("Resolucion", indiceResolucionActual);
        dropdownResolucion.RefreshShownValue();

        // Listeners
        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        dropdownResolucion.onValueChanged.AddListener(CambiarResolucion);
        toggle.onValueChanged.AddListener(ActivarPantallaCompleta);

        // Asegurar que el estado de la resolución refleje si está en pantalla completa
        dropdownResolucion.interactable = !pantallaCompleta;
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreenMode = pantallaCompleta ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.fullScreen = pantallaCompleta;
        dropdownResolucion.interactable = !pantallaCompleta; // Desactivar dropdown si es fullscreen

        PlayerPrefs.SetInt("PantallaCompleta", pantallaCompleta ? 1 : 0); // Guardar estado
        PlayerPrefs.Save();
    }

    private void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
        PlayerPrefs.SetFloat("Volumen", valor);
        PlayerPrefs.Save();
    }

    private void CambiarResolucion(int indice)
    {
        Resolution seleccionada = resoluciones[indice];
        Screen.SetResolution(seleccionada.width, seleccionada.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolucion", indice);
        PlayerPrefs.Save();
    }
}
