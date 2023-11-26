using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class SimulationBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private SimulationPort simulationPort;

    [SerializeField]private float elapsedFrames;
    
    private void Update()
    {
        Profiler.BeginSample("Simulation", this);
        simulationPort.SignalBeginUpdate();
        simulationPort.SignalIntegration();
        simulationPort.SignalDetection();
        simulationPort.SignalResolution();
        simulationPort.SignalEndUpdate();
        elapsedFrames++;
        if (elapsedFrames >= settings.SimulationDuration)
        {
            experimentPort.SignalEndSimulation();
            elapsedFrames = 0;
        }
        Profiler.EndSample();
    }
}
