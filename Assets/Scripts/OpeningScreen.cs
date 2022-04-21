using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(OpeningTimer());
    }

    IEnumerator OpeningTimer()
    {
        yield return new WaitForSeconds(10.1f);

        SceneManager.LoadScene(1);
    }
}
