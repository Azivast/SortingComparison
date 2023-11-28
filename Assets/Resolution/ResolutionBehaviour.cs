using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private SphereCollection spheres;

    private float frameStartTime, frameTotalTime;
    
    private void OnEnable() {
        simulationPort.OnResolution += OnResolution;
    }

    private void OnDisable() {
        simulationPort.OnResolution -= OnResolution;
    }

    private void OnResolution() {
        UnityEngine.Profiling.Profiler.BeginSample("Resolution", this);
        frameStartTime = Time.realtimeSinceStartup;
        spheres.Behaviours = settings.Algorithm.Sort(spheres.Behaviours);
        frameTotalTime = Time.realtimeSinceStartup-frameStartTime;
        if (frameTotalTime >= settings.CancelTime) {
            experimentPort.SignalEndSimulation();
        }
        else simulationPort.SignalNewFrameTime(frameTotalTime);
        
        for (int i = 0; i < settings.SpheresToHighlight; i++) {
            spheres.Behaviours[i].Highlighted = true;
        }
        for (int i = settings.SpheresToHighlight; i < spheres.Behaviours.Count; i++) {
            spheres.Behaviours[i].Highlighted = false;
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
