using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class waterBarrier : MonoBehaviour
{
    public GameObject barrierObject; // Reference to the barrier object
    public float barrierDuration = 5f; // Duration for which the barrier stays on

    private bool isBarrierActive = false;
    
    void Update()
    {
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleBarrier();
        }
    }

    void ToggleBarrier()
    {
        if (!isBarrierActive)
        {
            // Turn the barrier object on
            barrierObject.SetActive(true);
            isBarrierActive = true;
            // Start a coroutine to turn off the barrier after a duration
            StartCoroutine(TurnOffBarrierAfterDelay());
        }
    }

    IEnumerator TurnOffBarrierAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(barrierDuration);

        // Turn the barrier object off
        barrierObject.SetActive(false);
        isBarrierActive = false;
    }
}
