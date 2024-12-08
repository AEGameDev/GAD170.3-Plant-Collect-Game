using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantCollector : MonoBehaviour
{
    // Variables for Plant Collection
    public float collectionRange = 1f;
    public KeyCode collectKey = KeyCode.E;
    public TextMeshProUGUI pickupPrompt; // Reference to the UI Text element
    public Plant currentPlant;
    public bool carryingPlant = false;

    void Update()
    {
        // If Not Carrying Plant & Plant is in Range. Allow Player to Press 'E' to Collect Plant (Also Includes UI Text Prompt Set Active)
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
            // Pickup Prompt Inactive if Carrying Plant
            pickupPrompt.gameObject.SetActive(false);
        }
    }

    // Once Player Makes Input, Plant Becomes Child of Player
    void CollectPlant()
    {
        carryingPlant = true;
        currentPlant.transform.SetParent(transform);
        currentPlant.transform.localPosition = new Vector3(0, 1, -1);
        pickupPrompt.gameObject.SetActive(false);
    }

    // Resets Collection Ability, So Player can Collect Plant on Next Run
    public void ResetCollector()
    {
        carryingPlant = false;
        currentPlant = null;
        pickupPrompt.gameObject.SetActive(false); 
    }
}






