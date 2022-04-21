using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float speed;
    [Tooltip("SoundOffset is based on seconds")]
    public float soundOffset = 0.03f;
    public List<AudioClip> playerFootstepsAudioClipList;
    public AudioSource playerSoundsAudioSource;
    private Vector2 moveDirection;
    private int currentFootstepSound;

    private Animator animator;

    private bool isMoving = false;
   

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = moveDirection * speed;
        PlayFootstepSound();
        if(rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {   
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        animator.SetBool("isMoving", rb.velocity != Vector2.zero);
        if(rb.velocity != Vector2.zero)
        {
            animator.SetBool("MovingSide", rb.velocity.x != 0);
            animator.SetBool("MovingDown", rb.velocity.y < 0);
        }
        else
        {
            animator.SetBool("MovingDown", true);
        }
    }


    public void PlayFootstepSound()
    {
        if (rb.velocity != Vector2.zero & !playerSoundsAudioSource.isPlaying)
        {
            playerSoundsAudioSource.clip = GetFootstepClip();
            playerSoundsAudioSource.PlayDelayed(playerFootstepsAudioClipList[currentFootstepSound].length + (soundOffset * rb.velocity.normalized.magnitude));
        }
    }

    private AudioClip GetFootstepClip()
    {
        currentFootstepSound = Mathf.Abs(currentFootstepSound - 1);
        return playerFootstepsAudioClipList[currentFootstepSound];
    }
}
