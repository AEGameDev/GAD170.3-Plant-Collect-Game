using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCalculator : MonoBehaviour
{
    // Refrencing Greenhouse Class
    private Greenhouse greenhouse;

    void Start()
    {
        greenhouse = FindObjectOfType<Greenhouse>();
    }

    // Calcultes and Returns Run Score Based of Value of Plant * Remaing Health / 100
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

