using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        rb.velocity = moveDirection * speed;
    }
}
