using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExperimentSettings", menuName = "ExperimentSettings")]
public class ExperimentSettings : ScriptableObject
{
    public int StartSpheres = 20;
    public int MaxSpheres = 20;
    public int SphereIncrease = 20;
    public int IncreaseInterval = 300;
    public int SpheresToHighlight = 10;
    public int Seed = 1234567;
    
    public int SampleRate = 10;
    public float CancelTime= 1.0f;
    
    public SortingAlgorithm Algorithm;
}
