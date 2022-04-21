using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    // singleton class
    public static InteractionUI instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetText("", false);
    }

    public Text interactionText;

    public void SetText(string text , bool visibility)
    {
        if(visibility)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = text;
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
    
}
