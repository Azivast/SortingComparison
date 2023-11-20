using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;

    private void FixedUpdate()
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
