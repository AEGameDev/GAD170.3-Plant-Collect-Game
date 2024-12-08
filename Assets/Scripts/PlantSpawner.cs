using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    // Array of Plants to Spawn, Spawn Points for Plants & List to Keep Track of Spawned Plants
    public GameObject[] plantPrefabs; 
    public Transform[] spawnPoints; 
    private List<GameObject> spawnedPlants = new List<GameObject>();

    public void SpawnPlants()
    {
        // Ensure there are enough spawn points to avoid overlap
        if (spawnPoints.Length < 3)
        {
            Debug.LogError("Not enough spawn points for plants.");
            return;
        }

        // Shuffles Array to Randomise Spawn Point Order
        ShuffleArray(spawnPoints);

        // Spawns Plants At 3 Spawn Locations (Currently Only 3 Active)
        for (int i = 0; i < 3; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            GameObject plant = Instantiate(plantPrefabs[Random.Range(0, plantPrefabs.Length)], spawnPoint.position, Quaternion.identity);
            spawnedPlants.Add(plant); 
        }
    }

    // Destroy All Plants Stored in List & Clears List
    public void DestroySpawnedPlants()
    {
        foreach (GameObject plant in spawnedPlants)
        {
            Destroy(plant);
        }
        spawnedPlants.Clear(); 
    }

    // Shuffles Array Elements into Random Order
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





