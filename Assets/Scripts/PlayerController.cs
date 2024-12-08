using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Refrence to UI Text that Displays Plant Health
    public TextMeshProUGUI healthText;

    // Referncing PlantCollector Class
    private PlantCollector plantCollector;

    void Start()
    {
        // Getting PlantCollector Class
        plantCollector = GetComponent<PlantCollector>();

        // Using Funtions to Update UI Displaying Health
        UpdateHealthUI();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if Player is Colliding with Object Tagged as Obstacle, If Player Collides, Plant Takes Damage Based on Base Damage * Fargility of Current Plant
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (plantCollector != null && plantCollector.carryingPlant)
            {
                Plant currentPlant = plantCollector.currentPlant;

                if (currentPlant != null)
                {
                    float damage = 10f;
                    currentPlant.healthPercentage -= damage * currentPlant.fragility;

                    if (currentPlant.healthPercentage < 0)
                    {
                        currentPlant.healthPercentage = 0;
                    }

                    UpdateHealthUI(); 
                }
            }
        }
    }

    // Function to Update UI Displaying Health %
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



