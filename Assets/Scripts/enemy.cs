using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed;
    public Vector3 velocity;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction= player.transform.position - transform.position;
        direction.Normalize();

        transform.position= Vector3.SmoothDamp(transform.position, player.position, ref velocity, speed*0.01f);
        
        if(velocity.x<0)
        {
            spriteRenderer.flipY=true;
        }
        else if(velocity.x>0)
        {
            spriteRenderer.flipY=false;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 0.1f);
        
    }
}
