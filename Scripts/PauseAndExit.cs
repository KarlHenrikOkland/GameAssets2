using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndExit : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(GameIsPaused)
           {
               Resume();
           } 
           else 
           {
               Pause();
           }
        }
    }

    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonLook3>().enabled =  true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonLook3>().enabled =  false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }



}
