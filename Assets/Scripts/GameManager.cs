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

    public GameObject blackscreen;
    bool win = false;

    private void Update()
    {
        if(win)
        {
            blackscreen.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(blackscreen.GetComponent<CanvasGroup>().alpha, 1, Time.deltaTime * 0.5f);

            if(blackscreen.GetComponent<CanvasGroup>().alpha < 0.1f)
            {
                // mainmenu scene
                SceneManager.LoadScene(0);
            }
        }
    }

    public void WinGame()
    {
        win = true;

        Camera.main.gameObject.GetComponent<CameraFollower>().target = GameObject.FindGameObjectsWithTag("NPC")[0].transform;
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
