using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // use get axis raw so the input is either 1, 0 or -1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement
        movement.Normalize();

    }


    private void FixedUpdate()
    {
        // move player using rigid body2D in fixed update
        rb.velocity = new Vector2 (movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
