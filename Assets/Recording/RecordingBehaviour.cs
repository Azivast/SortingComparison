using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort; 
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private ExperimentSettings settings;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private string destination = "Results/";
    [SerializeField] private RecordingData data;

    private FileIO fileIO = new FileIO();
    
    private List<float> recordedTimes = new List<float>();
    private int samples = 0;

    private float frameTotalTime;
    private float frameStartTime;

    private void Start()
    {
        fileIO.Directory = destination;
    }

    private void OnEnable() {
        simulationPort.OnBeginUpdate += OnBeginUpdate;
        simulationPort.OnEndUpdate += OnEndUpdate;
        experimentPort.OnBeginSimulation += OnBeginSimulation;
        experimentPort.OnEndSimulation += OnEndSimulation;
        experimentPort.OnBeginExperiment += OnBeginExperiment;
        experimentPort.OnEndExperiment += OnEndExperiment;
    }

    private void OnDisable() { 
        simulationPort.OnBeginUpdate -= OnBeginUpdate;
        simulationPort.OnEndUpdate -= OnEndUpdate;
        experimentPort.OnBeginSimulation -= OnBeginSimulation;
        experimentPort.OnEndSimulation -= OnEndSimulation;
        experimentPort.OnBeginExperiment -= OnBeginExperiment;
        experimentPort.OnEndExperiment -= OnEndExperiment;
    }

    private void OnBeginUpdate()
    {
        frameStartTime = Time.realtimeSinceStartup;
    }
    private void OnEndUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("Add Recorded Data", this);
        frameTotalTime = Time.realtimeSinceStartup-frameStartTime;
        recordedTimes.Add(frameTotalTime);
        if (frameTotalTime >= settings.CancelTime) experimentPort.SignalEndSimulation();
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private void OnBeginSimulation()
    {
        recordedTimes.Clear();
        Debug.Log(settings.Algorithm.GetType().Name);
    }
    
    private void OnEndSimulation()
    {
        float averageTime = 0;
        foreach (int time in recordedTimes)
        {
            averageTime += time;
        }
        averageTime /= recordedTimes.Count;

        data.AddTime(averageTime);
    }

    private void OnBeginExperiment()
    {
        fileIO.VerifyWritable();
        recordedTimes.Clear();
    }

    private void OnEndExperiment()
    {
        fileIO.SaveFile(data);
    }
}
