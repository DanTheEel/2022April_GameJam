using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject quitPanel;
    public GameObject creditsPanel;
    public GameObject pauseMenuPanel;

    public static bool GameIsPaused = false;
    public AudioClip menuForwardSelect;
    public AudioClip menuBackSelect;
    public AudioSource menuAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        if(quitPanel != null)
        { 
            quitPanel.SetActive(false);
        }
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        
    }

    public void NegativeActionSFX()
    {
        menuAudioSource.PlayOneShot(menuBackSelect);
    }
    
    public void PositiveActionSFX()
    {
        menuAudioSource.PlayOneShot(menuForwardSelect);
    }
  
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        NegativeActionSFX();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        PositiveActionSFX();
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

   
    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
        PositiveActionSFX();
    }

    public void CloseCreditsScreen()
    {
        creditsPanel.SetActive(false);
        NegativeActionSFX();
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        NegativeActionSFX();
    }

    public void Paused()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        PositiveActionSFX();
    }

    public void QuitConfirmationPanel() 
    {
        quitPanel.SetActive(true);
        Time.timeScale = 0;
        PositiveActionSFX();
    }

    public void QuitCancel()
    {
        quitPanel.SetActive(false);
        Time.timeScale = 1;
        NegativeActionSFX();
    }

    public void QuitApplication()
    {
        Application.Quit();
        print("Quit Game Successful");
        PositiveActionSFX();
    }
}
