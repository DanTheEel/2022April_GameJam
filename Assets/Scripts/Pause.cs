using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public AudioSource clickSound;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlaySound();
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        PlaySound();
    }

    public void PlaySound()
    {
        clickSound.Play();
    }
}
