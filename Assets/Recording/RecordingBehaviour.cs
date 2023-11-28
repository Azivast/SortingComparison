using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    private int samplingCounter;

    private void OnEnable() {
        simulationPort.OnNewFrameTime += OnNewFrameTime;
    }

    private void OnDisable() {
        simulationPort.OnNewFrameTime -= OnNewFrameTime;
    }
    
    private void OnNewFrameTime(float time)
    {
        UnityEngine.Profiling.Profiler.BeginSample("Add Recorded Data", this);
        if (samplingCounter >= settings.RecordRate) {
            samplingCounter = 0;
            recordedTimes.Add(time);
            Debug.Log(time);
        }
        samplingCounter++;
        UnityEngine.Profiling.Profiler.EndSample();
    }

    public void ClearSimulationData()
    {
        recordedTimes.Clear();
        samplingCounter = settings.RecordRate; // always sample first frame of simulation
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
