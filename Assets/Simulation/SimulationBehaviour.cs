using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private int numberOfSpheres = 20;
    [SerializeField] private Vector2 simulationSpace = new Vector2(1920, 1080);
    [SerializeField] private Transform sphereParent;
    [SerializeField] private int Seed = 1234567;
    
    


    private void Start()
    {
        //TODO: Spawn additional spheres after n seconds
        Profiler.BeginSample("Spawn spheres", this);
        Random.InitState(Seed);
        spheres.Clear(numberOfSpheres);
        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphere = Instantiate(spheres.SpherePrefab, sphereParent);
            spheres.Add(sphere, simulationSpace, Seed, i);
        }

        Profiler.EndSample();
    }

    private void Update()
    {
        Profiler.BeginSample("Simulation", this);
        simulationPort.SignalBeginUpdate();
        simulationPort.SignalIntegration();
        simulationPort.SignalDetection();
        simulationPort.SignalResolution();
        simulationPort.SignalEndUpdate();
        Profiler.EndSample();
    }
}
