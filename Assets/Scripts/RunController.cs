using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RunController : MonoBehaviour
{
    // Variables for Accessing Classes, UI, Scoring & Run Count
    public PlantSpawner plantSpawner;
    public Greenhouse greenhouse;
    public PlantCollector plantCollector;
    public TextMeshProUGUI scoreText;
    public int totalRuns = 5;
    private int currentRun = 0;
    private int totalScore = 0;

    void Start()
    {
        StartNewRun();
    }

    public void EndRun()
    {
        // Calculates Score for Current Run
        int runScore = CalculateRunScore();
        totalScore += runScore;

        // Displays Score For Current Run
        scoreText.text = "Run " + (currentRun + 1) + " Score: " + runScore + "\nTotal Score: " + totalScore;

        // Plus 1 to Run Count
        currentRun++;

        // If Current Run is Less than Total Runs Possible Start New Run After Short Delay
        if (currentRun < totalRuns)
        {
            StartCoroutine(StartNewRunAfterDelay(2f));
        }
        else
        {
            // If Total Runs Possible Reached (5) Update Text 
            scoreText.text += "\nFinal Run Complete! Final Score: " + totalScore;
        }
    }

    IEnumerator StartNewRunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartNewRun();
    }

    // This Destroys Plants from Previous Run, Resets Greenhouse, Resets Plant Collector & Spawns New Plants for New Run
    void StartNewRun()
    {
        plantSpawner.DestroySpawnedPlants();

        greenhouse.ResetGreenhouse();

        plantCollector.ResetCollector();

        plantSpawner.SpawnPlants();
    }

    // Calcultes and Returns Run Score Based of Value of Plant * Remaing Health / 100
    int CalculateRunScore()
    {
        int runScore = 0;
        foreach (Plant plant in greenhouse.collectedPlants)
        {
            runScore += Mathf.RoundToInt(plant.dollarValue * (plant.healthPercentage / 100f));
        }
        return runScore;
    }
}




