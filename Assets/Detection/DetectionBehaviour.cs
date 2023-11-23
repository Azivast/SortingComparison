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

    public void OnDetection() {
        UnityEngine.Profiling.Profiler.BeginSample("Detection", this);
        for (int i = 0; i < spheres.Behaviours.Length; i++) {
            spheres.Behaviours[i].CalcDistance(targetSphere.transform.position);
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
