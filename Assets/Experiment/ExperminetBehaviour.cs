using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExperminetBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private RecordingData data;
    [SerializeField] private SphereManager sphereManager;
    [SerializeField] private RecordingBehaviour recordingBehaviour;
    [SerializeField] private TMP_Text text;
    [SerializeField] private int startSpheres = 20;
    [SerializeField] private int maxSpheres = 2000;
    [SerializeField] private int sphereIncrease = 20;
    [SerializeField] private int spheresToHighlight = 10;
    [SerializeField] private float simulationDuration = 3600;
    [SerializeField] private Vector2 simulationSpace = new Vector2(5, 5);
    [SerializeField] private int seed = 1234567;

    [SerializeField] private int sampleRate = 10;
    [SerializeField] private float cancelTime = 1.0f;
    
    [SerializeField] private SortingAlgorithm[] AlgortihmsToTest;
    
    private bool simulationFinished = false;

    private void OnEnable()
    {
        experimentPort.OnEndSimulation += OnEndSimulation;
    }

    private void OnDisable()
    {
        experimentPort.OnEndSimulation -= OnEndSimulation;
    }

    private void Awake()
    {
        UpdateSettings();
    }

    private void Start()
    {
        StartCoroutine(RunExperiments());
    }

    private void UpdateSettings()
    {
        settings.StartSpheres = startSpheres;
        settings.MaxSpheres = maxSpheres;
        settings.SphereIncrease = sphereIncrease;
        settings.SpheresToHighlight = spheresToHighlight;
        settings.SimulationDuration = simulationDuration;
        settings.Seed = seed;
        settings.SampleRate = sampleRate;
        settings.CancelTime = cancelTime;
    }

    private IEnumerator RunExperiments()
    {
        string firstRow = "spheres";
        foreach (var algorithm in AlgortihmsToTest)
        {
            firstRow += ";" + algorithm.GetType().Name;
        }
        data.Reset(firstRow);
        recordingBehaviour.NewExperimentData();
        
        for (int spheres = startSpheres; spheres <= maxSpheres; spheres += sphereIncrease) 
        {
            data.NewBallAmount(spheres);
            foreach (var algorithm in AlgortihmsToTest)
            {
                // Setup simulation
                simulationFinished = false;
                Random.InitState(settings.Seed);
                sphereManager.Spawn(spheres, seed, simulationSpace);
                recordingBehaviour.ClearSimulationData();
                settings.Algorithm = algorithm;
                text.text = $"{spheres} spheres : {algorithm.GetType().Name}";
                
                // Run algorithm
                experimentPort.SignalBeginSimulation();
                
                yield return new WaitUntil(() => simulationFinished);
                
                // Store results
                recordingBehaviour.StoreSimulationData();
            }
        }
        
        recordingBehaviour.WriteExperimentData();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    private void OnEndSimulation()
    {
        simulationFinished = true;
    }
}
