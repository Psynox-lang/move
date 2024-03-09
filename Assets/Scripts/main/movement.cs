using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5;     
    [SerializeField] float MaxSpeed = 25;
    [SerializeField] float speedReduction = 0f;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer outlinespriteRenderer;
    [SerializeField] SpriteRenderer dedspriteRenderer;

    public Rigidbody2D rb;
    Quaternion target;

    // Previous movement direction
    private Vector2 prevDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        if (movement != Vector2.zero)
        {
            // Check if direction changed abruptly
            if (Vector2.Dot(movement, prevDir) < 0)
            {
                // Reset velocity when changing direction abruptly
                rb.velocity = Vector2.zero;
            }

            prevDir = movement;

            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            target = Quaternion.AngleAxis(angle, Vector3.forward);

            rb.AddForce(movement * speed, ForceMode2D.Force);
            if (rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * MaxSpeed;
            }

            // Flip sprite if moving horizontally
            spriteRenderer.flipY = (movement.x < 0);
            outlinespriteRenderer.flipY = (movement.x < 0);
            dedspriteRenderer.flipY = (movement.x < 0);
        }

        // Smooth rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 0.1f);
    }

    public void RedSpeed()
    {
        rb.velocity *= speedReduction;
    }
}
