using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantCollector : MonoBehaviour
{
    public float collectionRange = 1f;
    public KeyCode collectKey = KeyCode.E;
    public TextMeshProUGUI pickupPrompt; // Reference to the UI Text element
    public Plant currentPlant;
    public bool carryingPlant = false;

    void Update()
    {
        if (!carryingPlant)
        {
            bool plantInRange = false;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, collectionRange);
            foreach (var hitCollider in hitColliders)
            {
                Plant plant = hitCollider.GetComponent<Plant>();
                if (plant != null)
                {
                    currentPlant = plant;
                    plantInRange = true;

                    if (Input.GetKeyDown(collectKey))
                    {
                        CollectPlant();
                    }
                    break;
                }
            }
            pickupPrompt.gameObject.SetActive(plantInRange);
        }
        else
        {
            // Ensure the prompt is deactivated if carrying a plant
            pickupPrompt.gameObject.SetActive(false);
        }
    }

    void CollectPlant()
    {
        carryingPlant = true;
        currentPlant.transform.SetParent(transform);
        currentPlant.transform.localPosition = new Vector3(0, 1, -1);
        pickupPrompt.gameObject.SetActive(false); // Hide the prompt when plant is collected
    }

    public void ResetCollector()
    {
        carryingPlant = false;
        currentPlant = null;
        pickupPrompt.gameObject.SetActive(false); // Hide the prompt when resetting
    }
}






