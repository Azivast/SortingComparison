using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;

    private void OnEnable() {
        simulationPort.OnResolution += OnResolution;
    }

    private void OnDisable() {
        simulationPort.OnResolution -= OnResolution;
    }

    private void OnResolution() {
        UnityEngine.Profiling.Profiler.BeginSample("Resolution", this);
        spheres.Behaviours = settings.Algorithm.Sort(spheres.Behaviours);
        for (int i = 0; i < settings.SpheresToHighlight; i++) {
            spheres.Behaviours[i].Highlighted = true;
        }
        for (int i = settings.SpheresToHighlight; i < spheres.Behaviours.Count; i++) {
            spheres.Behaviours[i].Highlighted = false;
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
