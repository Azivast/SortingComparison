using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private Transform targetSphere;

    private void OnEnable() {
        simulationPort.OnDetection += OnDetection;
    }

    private void OnDisable() {
        simulationPort.OnDetection -= OnDetection;
    }

    private void OnDetection() {
        UnityEngine.Profiling.Profiler.BeginSample("Detection", this);
        foreach (var behaviour in spheres.Behaviours)
        {
            behaviour.CalcDistance(targetSphere.transform.position);
        }
  
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
