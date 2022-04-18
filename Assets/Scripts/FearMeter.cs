using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearMeter : MonoBehaviour
{
    // singleton class => call it with => FearMeter.instance
    public static FearMeter instance;
    private void Awake()
    {
        instance = this;
    }


    public float maxFear = 100;
    float currentFear = 0;

    public Image fearMeterFill;

    public void AddFear(float fear)
    {
        currentFear += fear;

        fearMeterFill.fillAmount = currentFear / maxFear;

        if (currentFear >= 100)
        {
            // win / end game !!!

        }
    }


    void Start()
    {
        currentFear = 0;
        fearMeterFill.fillAmount = currentFear / maxFear;
    }

    void Update()
    {
        
    }
}
