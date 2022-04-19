using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject quitPanel;


    // Start is called before the first frame update
    void Start()
    {
        quitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayGame()
    {
        
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
