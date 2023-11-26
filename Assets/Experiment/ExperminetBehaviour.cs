using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperminetBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private int startSpheres = 20;
    [SerializeField] private int maxSpheres = 2000;
    [SerializeField] private int sphereIncrease = 20;
    [SerializeField] private int increaseInterval = 300;
    [SerializeField] private int spheresToHighlight = 10;
    [SerializeField] private int seed = 1234567;

    [SerializeField] private int sampleRate = 10;
    [SerializeField] private float cancelTime = 1.0f;
    
    [SerializeField] private SortingAlgorithm[] AlgortihmsToTest;

    private void Awake()
    {
        UpdateSettings();
    }

    private void Start()
    {
        experimentPort.SignalBeginSimulation();
    }

    private void UpdateSettings()
    {
        settings.StartSpheres = startSpheres;
        settings.MaxSpheres = maxSpheres;
        settings.SphereIncrease = sphereIncrease;
        settings.IncreaseInterval = increaseInterval;
        settings.SpheresToHighlight = spheresToHighlight;
        settings.Seed = seed;
        settings.SampleRate = sampleRate;
        settings.CancelTime = cancelTime;
    }

    private void RunExperiments()
    {
        for (int spheres = startSpheres; spheres < maxSpheres; spheres += sphereIncrease) 
        {
            foreach (var algorithm in AlgortihmsToTest) {
                RunSimulation(algorithm, spheres);
                // Store data?
            }
        }
        
        // Once finished write data to file
    }

    private void RunSimulation(SortingAlgorithm algorithm, int spheres)
    {
        // Spawn spheres
        experimentPort.SignalSpawnSpheres(startSpheres, seed);

        // Run algorithm
        settings.Algorithm = algorithm;
        experimentPort.SignalBeginSimulation();

        // Save Data
    }
}
