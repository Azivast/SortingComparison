using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ExperimentPort", menuName = "ExperimentPort")]
public class ExperimentPort : ScriptableObject
{
    public UnityAction<>( //TODO wtf even is this
        int sphereAmount, 
        int sphereIncrease, 
        int spheresToHighligt,
        Vector2 simulationSpace,
        int seed,
        int sampleRate,
        float cancelTime) 
        OnBeginSimulation;
    
    public UnityAction OnEndSimulation = delegate {};

    public void SignalBeginSimulation() => OnBeginSimulation.Invoke();
}
