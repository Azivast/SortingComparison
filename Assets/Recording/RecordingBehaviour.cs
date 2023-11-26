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
        experimentPort.OnBeginSimulation += OnBeginSimulation;
        experimentPort.OnEndSimulation += OnEndSimulation;
    }

    private void OnDisable() { 
        simulationPort.OnBeginUpdate -= OnBeginUpdate;
        simulationPort.OnEndUpdate -= OnEndUpdate;
        experimentPort.OnBeginSimulation -= OnBeginSimulation;
        experimentPort.OnEndSimulation -= OnEndSimulation;
    }

    private void OnBeginUpdate()
    {
        frameStartTime = Time.realtimeSinceStartup;
    }
    private void OnEndUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("Add Recorded Data", this);
        frameTotalTime = frameStartTime - Time.realtimeSinceStartup;
        data.AddEntry(spheres.GameObjects.Count, frameTotalTime);
        if (frameTotalTime >= settings.CancelTime) experimentPort.SignalEndSimulation();
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private void OnBeginSimulation()
    {
        data.data.Clear();
        data.AlgorithmName = settings.Algorithm.GetType().Name;
        data.data.Add("Algorithm:");
        data.data.Add("Sphere Count;Frame Time");
        Debug.Log(settings.Algorithm.GetType().Name);
        fileIO.VerifyWritable();
    }
    
    private void OnEndSimulation()
    {
        if (fileIO.SaveFile(data))
        {
            Debug.Log("Simulation finished, result saved.");
            //TODO: This should not be done from here
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
            
    }
}
