using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class IntegrationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private SphereBehaviour target;

    private void OnEnable() {
        simulationPort.OnIntegration += OnIntegration;
    }

    private void OnDisable() {
        simulationPort.OnIntegration -= OnIntegration;
    }

    public void OnIntegration() {
        Profiler.BeginSample("Integration", this);
        target.Move();
        foreach (SphereBehaviour sphere in spheres.Behaviours) {
            sphere.Move();
        }
        Profiler.EndSample();
    }
}
