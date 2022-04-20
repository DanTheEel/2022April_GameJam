using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue;
    private float oneMinuteLeft;
    public Text timeText;
    public AudioSource oneMinuteLeftSound;
    public GameObject gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas.SetActive(false);
    }

    private void Start()
    {
        oneMinuteLeft = timeValue - 60;
        oneMinuteLeftSound.PlayDelayed(oneMinuteLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            gameOverCanvas.SetActive(true);
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
}