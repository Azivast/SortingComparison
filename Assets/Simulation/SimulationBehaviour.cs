using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private Vector2 simulationSpace = new Vector2(5, 5);
    [SerializeField] private Transform sphereParent;
    [SerializeField] private SphereBehaviour targetSphere;

    private int frame = 0;
    
    private void Start()
    {
        Random.InitState(settings.Seed);
        targetSphere.Setup(simulationSpace);
        spheres.Clear();
        SpawnSpheres(settings.StartSpheres);
    }

    private void Update()
    {
        Profiler.BeginSample("Spawn spheres", this);
        if (frame != 0 && frame%settings.IncreaseInterval == 0)
        {
            if (spheres.GameObjects.Count >= settings.MaxSpheres) experimentPort.SignalEndSimulation();
            else SpawnSpheres(settings.SphereIncrease);
        }
        Profiler.EndSample();
        Profiler.BeginSample("Simulation", this);
        simulationPort.SignalBeginUpdate();
        simulationPort.SignalIntegration();
        simulationPort.SignalDetection();
        simulationPort.SignalResolution();
        simulationPort.SignalEndUpdate();
        Profiler.EndSample();
        frame++;
    }

    private void SpawnSpheres(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject sphere = Instantiate(spheres.SpherePrefab, sphereParent);
            spheres.Add(sphere, simulationSpace, settings.Seed);
        }
    }
}
