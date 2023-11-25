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


    [SerializeField] private SortingAlgorithm selectedAlgorithm;

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
        settings.Algorithm = selectedAlgorithm;
    } 
}
