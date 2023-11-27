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
    [SerializeField] private RecordingData data;

    private FileIO fileIO = new FileIO();
    
    private List<float> recordedTimes = new List<float>();

    private float frameTotalTime;
    private float frameStartTime;
    private int samplingCounter;

    private void OnEnable() {
        simulationPort.OnBeginUpdate += OnBeginUpdate;
        simulationPort.OnEndUpdate += OnEndUpdate;
    }

    private void OnDisable() { 
        simulationPort.OnBeginUpdate -= OnBeginUpdate;
        simulationPort.OnEndUpdate -= OnEndUpdate;
    }

    private void OnBeginUpdate()
    {
        frameStartTime = Time.realtimeSinceStartup;
    }
    private void OnEndUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("Add Recorded Data", this);
        
        frameTotalTime = Time.realtimeSinceStartup-frameStartTime;
        
        if (samplingCounter >= settings.SampleRate) {
            samplingCounter = 0;
            recordedTimes.Add(frameTotalTime);
        }
        samplingCounter++;
        
        if (frameTotalTime >= settings.CancelTime) experimentPort.SignalEndSimulation();

        UnityEngine.Profiling.Profiler.EndSample();
    }

    public void ClearSimulationData()
    {
        recordedTimes.Clear();
        samplingCounter = settings.SampleRate; // always sample first frame of simulation
    }
    
    public void StoreSimulationData()
    {
        float averageTime = 0;
        foreach (float time in recordedTimes)
        {
            averageTime += time;
        }
        averageTime /= recordedTimes.Count;

        data.AddTime(averageTime);
    }

    public void NewExperimentData()
    {
        recordedTimes.Clear();
    }

    public void WriteExperimentData()
    {
        fileIO.SaveFile(data);
    }
}
