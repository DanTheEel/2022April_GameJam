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

    public List<GameObject> NPCs;
    private void Start()
    {
        foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPCs.Add(npc);
        }
    }

    private void Update()
    {
        int detectedNPCs = 0;
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC_Detection>().isBeingDetected && !npc.GetComponent<NPC_Behavior>().distracted)
            {
                detectedNPCs++;
            }
        }
        if (detectedNPCs > 0)
        {
            SetDetection(true);
        }
        else
        {
            SetDetection(false);
        }
    }

    public void SetDetection(bool isBeingDetected)
    {
        if (isBeingDetected)
        {
            if(detectionMeter < detectionDuration)
            {
                detectionMeter += Time.deltaTime * detectingSpeed;
            }
            if (detectionMeter >= detectionDuration)
            {
                // you are detected
                Debug.Log("THEY SAW YOUUU!!!");

                GameManager.instance.LoseGame();
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
