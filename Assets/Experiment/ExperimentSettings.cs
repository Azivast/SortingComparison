using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ExperimentSettings", menuName = "ExperimentSettings")]
public class ExperimentSettings : ScriptableObject
{
    public int SpheresToHighlight = 10;
    public float SimulationDuration = 3600;
    public int Seed = 1234567;
    
    public int RecordInterval = 10;
    public float CancelTime= 1.0f;
    
    public SortingAlgorithm Algorithm;
}
