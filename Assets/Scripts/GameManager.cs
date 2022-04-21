using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void WinGame()
    {

    }

    public void LoseGame()
    {
        // gameover scene
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        // mainmenu scene
        SceneManager.LoadScene(0);
    }
}
