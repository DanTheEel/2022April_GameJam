using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject quitPanel;
    public GameObject creditsPanel;


    // Start is called before the first frame update
    void Start()
    {
        quitPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCreditsScreen()
    {
        creditsPanel.SetActive(false);
    }

    public void QuitConfirmationPanel() 
    {
        quitPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitCancel()
    {
        quitPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Application.Quit();
        print("Quit Game Successful");
    }
}
