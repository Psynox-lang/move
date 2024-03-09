using System.Collections;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetPrefab;

    public GameObject portalPrefab;

    public int numberOfPlanets = 3;

    public float minPlanetSpawnInterval = 2f;

    public float maxPlanetSpawnInterval = 5f;

    public int numberOfPortals = 3;

    public float minPortalSpawnInterval = 0.2f;

    public float maxPortalSpawnInterval = 2f;

    public GameObject squareArea;

    void Update()
    {
        SpawnPlanetsPeriodically();
        SpawnPortalsPeriodically();
    }

    void SpawnPlanetsPeriodically()
    {
        // Adjust this condition based on your requirements
        if (Time.time % maxPlanetSpawnInterval < Time.deltaTime)
        {
            for (int i = 0; i < (int) Random.Range(1, numberOfPlanets); i++)
            {
                // Get bounds of the square area
                BoxCollider2D squareCollider =
                    squareArea.GetComponent<BoxCollider2D>();
                Bounds squareBounds = squareCollider.bounds;

                // Generate random position within the square bounds
                Vector2 spawnPosition =
                    new Vector2(Random
                            .Range(squareBounds.min.x, squareBounds.max.x),
                        Random.Range(squareBounds.min.y, squareBounds.max.y));

                GameObject newPlanet =
                    Instantiate(planetPrefab,
                    spawnPosition,
                    Quaternion.identity);
            }
        }
    }

    void SpawnPortalsPeriodically()
    {
        // Adjust this condition based on your requirements
        if (Time.time % maxPortalSpawnInterval < Time.deltaTime)
        {
            for (int i = 0; i < (int) Random.Range(1, numberOfPortals); i++)
            {
                // Get bounds of the square area
                BoxCollider2D squareCollider =
                    squareArea.GetComponent<BoxCollider2D>();
                Bounds squareBounds = squareCollider.bounds;

                // Generate random position within the square bounds
                Vector2 spawnPosition =
                    new Vector2(Random
                            .Range(squareBounds.min.x, squareBounds.max.x),
                        Random.Range(squareBounds.min.y, squareBounds.max.y));

                GameObject newPlanet =
                    Instantiate(portalPrefab,
                    spawnPosition,
                    Quaternion.identity);
            }
        }
    }
}
