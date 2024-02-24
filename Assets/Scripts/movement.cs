using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 dir = Vector2.right;
    public float speed = 5;     
    [SerializeField]
    float MaxSpeed = 25;
    public Rigidbody2D rb;
    Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

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
        transform.rotation = Quaternion.Slerp(transform.rotation,target,0.01f);
    }
}

