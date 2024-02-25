using System.Collections;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetPrefab;
    public int numberOfPlanets = 3;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;

    public GameObject squareArea;

    void Update()
    {
        SpawnPlanetsPeriodically();
    }

    void SpawnPlanetsPeriodically()
    {
        // Adjust this condition based on your requirements
        if (Time.time % maxSpawnInterval < Time.deltaTime)
        {
            for (int i = 0; i < numberOfPlanets; i++)
            {
                // Get bounds of the square area
                BoxCollider2D squareCollider = squareArea.GetComponent<BoxCollider2D>();
                Bounds squareBounds = squareCollider.bounds;

                // Generate random position within the square bounds
                Vector2 spawnPosition = new Vector2(
                    Random.Range(squareBounds.min.x, squareBounds.max.x),
                    Random.Range(squareBounds.min.y, squareBounds.max.y)
                );

                GameObject newPlanet = Instantiate(planetPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
