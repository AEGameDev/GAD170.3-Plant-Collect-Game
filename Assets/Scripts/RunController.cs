using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RunController : MonoBehaviour
{
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
        // Calculate score for the current run
        int runScore = CalculateRunScore();
        totalScore += runScore;

        // Display the score for the current run
        scoreText.text = "Run " + (currentRun + 1) + " Score: " + runScore + "\nTotal Score: " + totalScore;

        // Increment run count
        currentRun++;

        if (currentRun < totalRuns)
        {
            // Start a new run after a short delay
            StartCoroutine(StartNewRunAfterDelay(2f));
        }
        else
        {
            // All runs completed, display final score
            scoreText.text += "\nFinal Run Complete! Final Score: " + totalScore;
        }
    }

    IEnumerator StartNewRunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartNewRun();
    }

    void StartNewRun()
    {
        // Destroy plants from the previous run
        plantSpawner.DestroySpawnedPlants();

        // Reset the greenhouse for the new run
        greenhouse.ResetGreenhouse();

        // Reset the plant collector for the new run
        plantCollector.ResetCollector();

        // Spawn new plants
        plantSpawner.SpawnPlants();
    }

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




