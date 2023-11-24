using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ISortingAlgorithm))]
public class ResolutionBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private int spheresToHighlight = 10;
    private ISortingAlgorithm algorithm;

    private void Awake()
    {
        algorithm = GetComponent<ISortingAlgorithm>();
    }

    private void OnEnable() {
        simulationPort.OnResolution += OnResolution;
    }

    private void OnDisable() {
        simulationPort.OnResolution -= OnResolution;
    }

    private void OnResolution() {
        UnityEngine.Profiling.Profiler.BeginSample("Resolution", this);
        spheres.Behaviours = algorithm.Sort(spheres.Behaviours);
        for (int i = 0; i < spheresToHighlight; i++) {
            spheres.Behaviours[i].Highlighted = true;
        }
        for (int i = spheresToHighlight; i < spheres.Behaviours.Length; i++) {
            spheres.Behaviours[i].Highlighted = false;
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
