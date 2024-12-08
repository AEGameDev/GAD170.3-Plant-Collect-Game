using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthText; // Reference to the UI Text element for displaying health
    private PlantCollector plantCollector;

    void Start()
    {
        plantCollector = GetComponent<PlantCollector>();
        UpdateHealthUI();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (plantCollector != null && plantCollector.carryingPlant)
            {
                Plant currentPlant = plantCollector.currentPlant;

                if (currentPlant != null)
                {
                    // Example damage value, you can adjust this based on the obstacle's properties
                    float damage = 10f;
                    currentPlant.healthPercentage -= damage * currentPlant.fragility;

                    if (currentPlant.healthPercentage < 0)
                    {
                        currentPlant.healthPercentage = 0;
                    }

                    UpdateHealthUI(); // Update the health display
                }
            }
        }
    }

    void UpdateHealthUI()
    {
        if (plantCollector.currentPlant != null)
        {
            healthText.text = "Fruit Health: " + Mathf.RoundToInt(plantCollector.currentPlant.healthPercentage) + "%";
        }
        else
        {
            healthText.text = "Fruit Health: 100%";
        }
    }
}



