using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{   [Header("Movement Settings")]
    public float speed = 5;     
    [SerializeField]
    float MaxSpeed = 25;
    [SerializeField]
    float speedReduction = 0f;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    SpriteRenderer outlinespriteRenderer;
    [SerializeField]
    SpriteRenderer dedspriteRenderer;
    private Vector2 dir ;



    public Rigidbody2D rb;
    Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        
        if(rb.velocity.x<0 || horizontalInput<0)
        {
            spriteRenderer.flipY=true;
            outlinespriteRenderer.flipY=true;
            dedspriteRenderer.flipY=true;
        }
        else if(rb.velocity.x>0 || horizontalInput>0)
        {
            spriteRenderer.flipY=false;
            outlinespriteRenderer.flipY=false;
            dedspriteRenderer.flipY=false;
        }
        if (movement != Vector2.zero)
        {
            dir = movement.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            target = Quaternion.AngleAxis(angle, Vector3.forward);
            
            rb.AddForce(dir * speed,ForceMode2D.Force);
            if(rb.velocity.magnitude> MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * MaxSpeed;
            }
        }
        //rb.velocity = dir * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation,target,0.1f);
    }

    public void RedSpeed(){
        rb.velocity *= speedReduction;
    }
}

