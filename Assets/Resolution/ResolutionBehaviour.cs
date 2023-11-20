using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionBehaviour : MonoBehaviour
{
    [SerializeField] private SimulationPort simulationPort;
    [SerializeField] private SphereCollection spheres;
    [SerializeField] private ISortingAlgorithm algorithm = new InsertSort();
    
    private const int SPHERESTOHIGHLIGHT = 10;

    private void OnEnable() {
        simulationPort.OnResolution += OnResolution;
    }

    private void OnDisable() {
        simulationPort.OnResolution -= OnResolution;
    }

    private void OnResolution() {
        UnityEngine.Profiling.Profiler.BeginSample("Resolution", this);
        algorithm.Sort(spheres.Behaviours);

        for (int i = 0; i < SPHERESTOHIGHLIGHT; i++) {
            spheres.Behaviours[i].Highlighted = true;
        }
        for (int i = SPHERESTOHIGHLIGHT; i < spheres.Behaviours.Length; i++) {
            spheres.Behaviours[i].Highlighted = false;
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
