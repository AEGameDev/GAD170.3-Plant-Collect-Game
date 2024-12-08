using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private Greenhouse greenhouse;

    void Start()
    {
        greenhouse = FindObjectOfType<Greenhouse>();
    }

    public int CalculateTotalScore()
    {
        int totalScore = 0;
        foreach (Plant plant in greenhouse.collectedPlants)
        {
            totalScore += Mathf.RoundToInt(plant.dollarValue * (plant.healthPercentage / 100f));
        }
        return totalScore;
    }
}

