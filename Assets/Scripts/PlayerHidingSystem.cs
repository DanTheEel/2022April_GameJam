using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHidingSystem : MonoBehaviour
{
    // singleton class
    public static PlayerHidingSystem instance;
    private void Awake()
    {
        instance = this;
    }

    public bool hidden;

}
