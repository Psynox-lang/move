using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetobs : MonoBehaviour
{
    public float deleteTime = 3f; // Time in seconds before the planet is deleted if off-screen

    public float offScreenTimeThreshold = 2f; // Time in seconds the planet should be off-screen continuously to be deleted

    private float offScreenTimer = 0f;

    private bool isOffScreen = false;

    public ScoreManager sc;

    void Start()
    {
        float slsize = Random.Range(0.3f, 0.7f);
        transform.localScale = new Vector3(slsize, slsize, 1);
        sc =
            GameObject
                .FindWithTag("GameController")
                .GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, 1f);
    }

    // Start is called before the first frame update
    /*void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/
    private void Update()
    {
        // Check if the planet is off-screen
        if (!IsVisible())
        {
            isOffScreen = true;
            offScreenTimer += Time.deltaTime;

            // If off-screen for more than offScreenTimeThreshold, delete the planet
            if (offScreenTimer >= offScreenTimeThreshold)
            {
                Destroy (gameObject);
            }
        }
        else
        {
            isOffScreen = false;
            offScreenTimer = 0f;
        }
    }

    private bool IsVisible()
    {
        // Check if the planet is visible on the screen
        Vector3 screenPoint =
            Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 &&
        screenPoint.x < 1 &&
        screenPoint.y > 0 &&
        screenPoint.y < 1 &&
        screenPoint.z > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (
                other
                    .gameObject
                    .GetComponent<colourChangePortal>()
                    .body
                    .color ==
                transform.GetChild(0).GetComponent<colourPlanet>().body.color
            )
            {
                sc.incrementScore(25);
                Destroy (gameObject);
            }
            else
            {
                other
                    .gameObject
                    .GetComponent<movement>().RedSpeed();
                Destroy (gameObject);
            }
        }
    }
}
