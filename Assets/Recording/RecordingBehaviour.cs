using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort; 
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private string destination = "Data/";

    private RecordingData data = new RecordingData();
    private FileIO fileIO = new FileIO();

    private float frameTotalTime;
    private float frameStartTime;

    private void Start()
    {
        fileIO.Directory = destination;
    }

    private void OnEnable() {
        simulationPort.OnBeginUpdate += OnBeginUpdate;
        simulationPort.OnEndUpdate += OnEndUpdate;
        experimentPort.OnEndSimulation += OnEndSimulation;
    }

    private void OnDisable() {
        simulationPort.OnBeginUpdate -= OnBeginUpdate;
        simulationPort.OnEndUpdate -= OnEndUpdate;
        experimentPort.OnEndSimulation -= OnEndSimulation;
    }

    private void OnBeginUpdate()
    {
        frameStartTime = Time.time;
    }
    private void OnEndUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("Recording", this);
        frameTotalTime = frameStartTime - Time.time;
        //data.AddEntry(frameTotalTime);
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private void OnEndSimulation()
    {
        fileIO.SaveFile(data);
    }
}
