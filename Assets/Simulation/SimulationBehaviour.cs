using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private int numberOfSpheres;
    [SerializeField] private Vector2 simulationSpace = new Vector2(1920, 1080);
    [SerializeField] private Transform sphereParent;


    private void Start()
    {
        //TODO: Spawn additional spheres after n seconds
        Profiler.BeginSample("Spawn spheres", this);
        spheres.Clear(numberOfSpheres);
        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphere = Instantiate(spheres.SpherePrefab, sphereParent);
            spheres.Add(sphere, simulationSpace, i);
        }

        Profiler.EndSample();
    }

    private void Update()
    {
        Profiler.BeginSample("Simulation", this);
        simulationPort.SignalBeginFixedUpdate();
        simulationPort.SignalIntegration();
        simulationPort.SignalDetection();
        simulationPort.SignalResolution();
        simulationPort.SignalEndFixedUpdate();
        Profiler.EndSample();
    }
}
