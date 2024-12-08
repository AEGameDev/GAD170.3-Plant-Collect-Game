using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenhouse : MonoBehaviour
{
    // Using a List to Store Collected Plants
    public List<Plant> collectedPlants = new List<Plant>();

    // When Player Reaches Greenhouse (Truck Bed) The Plant Becomes Child of Greenhouse & Adds to List. Also Ends Current Run!
    void OnTriggerEnter2D(Collider2D other)
    {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null)
        {
            collectedPlants.Add(plant);
            plant.transform.SetParent(transform);
            plant.transform.localPosition = Vector3.zero;
 
            FindObjectOfType<RunController>().EndRun();
        }
    }

    public void ResetGreenhouse()
    {
        // This Destroys Remaining Plants in Current Run
        foreach (Plant plant in collectedPlants)
        {
            Destroy(plant.gameObject);
        }

        // Clearing List of Collected Plants
        collectedPlants.Clear();
    }
}


