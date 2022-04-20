using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float speed;
    public List<AudioClip> playerFootstepsAudioClipList;
    public AudioSource playerSoundsAudioSource;
    private Vector2 moveDirection;
    public int currentFootstepSound;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        rb.velocity = moveDirection * speed;
        PlayFootstepSound();
    }

    private void PlayFootstepSound()
    {
        if (moveDirection != Vector2.zero & !playerSoundsAudioSource.isPlaying)
        {
            playerSoundsAudioSource.clip = GetFootstepClip();
            playerSoundsAudioSource.Play();
        }
    }

    private AudioClip GetFootstepClip()
    {
        currentFootstepSound = Mathf.Abs(currentFootstepSound - 1);
        return playerFootstepsAudioClipList[currentFootstepSound];
    }
    
}
