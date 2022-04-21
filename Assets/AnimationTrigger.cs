using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator anim;

    public void SetAnimation()
    {
        StartCoroutine(AnimationTimer());
    }

    IEnumerator AnimationTimer()
    {
        anim.SetBool("TriggerAnimation 0", true);
        yield return new WaitForSeconds(5f);

        anim.SetBool("TriggerAnimation 0", false);
    }
    
}
