using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManeger : MonoBehaviour
{
    public void EmpezarVs()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SalirGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
                Application.Quit();
#endif

    }
}

