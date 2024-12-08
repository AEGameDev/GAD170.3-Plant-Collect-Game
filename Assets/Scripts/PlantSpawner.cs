using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject[] plantPrefabs; // Array of plant prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points
    private List<GameObject> spawnedPlants = new List<GameObject>(); // List to keep track of spawned plants

    public void SpawnPlants()
    {
        // Ensure there are enough spawn points to avoid overlap
        if (spawnPoints.Length < 3)
        {
            Debug.LogError("Not enough spawn points for plants.");
            return;
        }

        // Shuffle the spawn points array to randomize the order
        ShuffleArray(spawnPoints);

        // Spawn plants at the first 3 shuffled spawn points
        for (int i = 0; i < 3; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            GameObject plant = Instantiate(plantPrefabs[Random.Range(0, plantPrefabs.Length)], spawnPoint.position, Quaternion.identity);
            spawnedPlants.Add(plant); // Add the spawned plant to the list
        }
    }

    public void DestroySpawnedPlants()
    {
        foreach (GameObject plant in spawnedPlants)
        {
            Destroy(plant);
        }
        spawnedPlants.Clear(); // Clear the list after destroying all plants
    }

    void ShuffleArray(Transform[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Transform temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}





