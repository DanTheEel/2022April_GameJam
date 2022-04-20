using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float timer;

    void Start()
    {
        StartCoroutine(SetTimer());
    }

    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(timer);

        GameObject.Destroy(this.gameObject);
    }
}
