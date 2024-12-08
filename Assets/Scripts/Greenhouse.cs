using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenhouse : MonoBehaviour
{
    public List<Plant> collectedPlants = new List<Plant>();

    void OnTriggerEnter2D(Collider2D other)
    {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null)
        {
            collectedPlants.Add(plant);
            plant.transform.SetParent(transform);
            plant.transform.localPosition = Vector3.zero;

            // End the run when a plant is deposited
            FindObjectOfType<RunController>().EndRun();
        }
    }

    public void ResetGreenhouse()
    {
        // Destroy all plants collected in the current run
        foreach (Plant plant in collectedPlants)
        {
            Destroy(plant.gameObject);
        }

        // Clear the list of collected plants
        collectedPlants.Clear();
    }
}


