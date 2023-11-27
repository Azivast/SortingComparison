using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ExperimentPort", menuName = "ExperimentPort")]
public class ExperimentPort : ScriptableObject
{
    public UnityAction OnBeginSimulation = delegate {};
    public UnityAction OnEndSimulation = delegate {};
    
    public void SignalBeginSimulation() => OnBeginSimulation.Invoke();
    public void SignalEndSimulation() => OnEndSimulation.Invoke();
}
