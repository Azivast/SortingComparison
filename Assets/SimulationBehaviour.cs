using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort = null;

    private void FixedUpdate()
    {
        Profiler.BeginSample("Simulation", this);
        simulationPort.SignalBeginFixedUpdate();
        simulationPort.SignalIntegration();
        simulationPort.SignalSorting();
        simulationPort.SignalResolution();
        simulationPort.SignalEndFixedUpdate();
        
        Profiler.EndSample();
    }
}
