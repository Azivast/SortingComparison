using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class IntegrationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereBehaviour[] spheres;

    private void OnEnable() {
        simulationPort.OnIntegration += OnIntegration;
    }

    private void OnDisable() {
        simulationPort.OnIntegration -= OnIntegration;
    }

    public void OnIntegration() {
        Profiler.BeginSample("Integration", this);
        //integrationPort.SignalBeginIntegration();
        foreach (SphereBehaviour sphere in spheres) {
            sphere.Move();
        }
        //integrationPort.SignalEndIntegration();
        Profiler.EndSample();
    }
}
