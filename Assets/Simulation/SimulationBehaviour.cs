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

    [SerializeField]private int elapsedFrames;

    private bool running = false;
    
    private void OnEnable() {
        experimentPort.OnBeginSimulation += OnStart;
    }

    private void OnDisable() { 
        experimentPort.OnBeginSimulation -= OnEnd;
    }
    
    public void Update() {
        if (!running) return;
        
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

    private void OnStart() {
        running = true;
    }
    private void OnEnd() {
        running = false;
    }
}
