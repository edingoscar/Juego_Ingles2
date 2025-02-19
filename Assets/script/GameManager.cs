using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public GameObject WinScreen;
    public static int level;
    public bool win = false;
    public bool canPause = true;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        win = false;
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!win){
            if(Input.GetKeyDown(KeyCode.Escape) && canPause){
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if(pauseMenu.activeSelf){
                    Time.timeScale = 0f;
                }else{
                    Time.timeScale = 1f;
                }
            }
        }else{
            if(WinScreen != null){
                WinScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
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
}
