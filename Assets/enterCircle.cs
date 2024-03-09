using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCircle : MonoBehaviour
{
    public GameObject player;
    public float radius= 5f;
    private Renderer rendererComponent;
     public float timerDuration = 1f; // Duration of the timer in seconds
    public float timer = 0f; // Current timer value
    public bool timerRunning = false; // Flag to indicate whether the timer is running


    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.material.color = Color.white;

    }

    void FixedUpdate()
    {
        //SetColorBasedOnPlayerDistance();
    }

    // void SetColorBasedOnPlayerDistance()
    // {
    //     if (player != null)
    //     {
    //         float distance = Vector3.Distance(transform.position, player.transform.position).normalized;
    //         if (distance <= radius)
    //         {
    //             // Player is inside the radius
    //             rendererComponent.material.color = Color.red;
    //         }
    //         else
    //         {
    //             // Player is outside the radius
    //             rendererComponent.material.color = Color.clear; // Transparent
    //         }
    //     }
    // }
    //  private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.tag=="Player"){
    //         rendererComponent.material.color= Color.red;
    //     if (!timerRunning)
    //         {
    //     timer = timerDuration;
    //         timerRunning = true;
    //     }
    //     }
    //  }
    //  private void OnTriggerExit2D(Collider2D other) {
    //     if(other.tag=="Player"){
    //         rendererComponent.material.color= Color.clear;
    //         timerRunning=false;
    //         timer=0f;
    //     }
    //  }
     
    //   private void Update()
    // {
    //     // Update the timer if it's running
    //     if (timerRunning)
    //     {
    //         timer -= Time.deltaTime;

    //         // Check if the timer has ended
    //         if (timer <= 0)
    //         {
    //             Debug.Log("Timer has ended!");
    //             timerRunning = false;
    //         }
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the player's color to red
           rendererComponent.material.color= Color.red;

            // Start the timer
            if (!timerRunning)
            {
                timer = timerDuration;
                timerRunning = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the timer
            rendererComponent.material.color= Color.white;
            timerRunning = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        // Update the timer if it's running
        if (timerRunning)
        {
            timer -= Time.deltaTime;

            // Check if the timer has ended
            if (timer <= 0)
            {
                ffprint();
                Debug.Log("Timer has ended!");
                timerRunning = false;
            }
        }
    }

    void ffprint(){
        Debug.Log("Timer has ended!");
    }


     void OnDrawGizmosSelected()
    {
        // Draw a wire sphere around the enemy to represent the radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}