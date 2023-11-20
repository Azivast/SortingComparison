using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private SphereBehaviour targetSphere;

    private void OnEnable() {
        simulationPort.OnDetection += OnDetection;
    }

    private void OnDisable() {
        simulationPort.OnDetection -= OnDetection;
    }

    public void OnDetection() {
        UnityEngine.Profiling.Profiler.BeginSample("Detection", this);
        foreach (SphereBehaviour sphere in spheres.Behaviours) {
            sphere.CalcDistance(targetSphere.transform.position);
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
