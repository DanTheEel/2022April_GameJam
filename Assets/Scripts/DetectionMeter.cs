using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionMeter : MonoBehaviour
{
    // singleton class => call it with => DetectionMeter.instance
    public static DetectionMeter instance;
    private void Awake()
    {
        instance = this;
    }

    float detectionMeter = 0;
    public float detectionDuration = 2;     // seconds
    public float detectingSpeed = 1;
    public float losingSpeed = 1;

    public Image detectionMeterFill;

    public void SetDetection(bool isBeingDetected)
    {
        if (isBeingDetected)
        {
            detectionMeter += Time.deltaTime * detectingSpeed;
            if (detectionMeter >= detectionDuration)
            {
                // you are detected
                Debug.Log("THEY SAW YOUUU!!!");
            }
        }
        else
        {
            if (detectionMeter > 0)
            {
                detectionMeter -= Time.deltaTime * losingSpeed;
            }
        }

        detectionMeterFill.fillAmount = detectionMeter / detectionDuration;
    }
}
