using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ExperimentPort", menuName = "ExperimentPort")]
public class ExperimentPort : ScriptableObject
{
    public UnityAction OnBeginSimulation = delegate {};
    public UnityAction OnEndSimulation = delegate {};
    public UnityAction<int,int,Vector2> OnSpawnSpheres = delegate(int amount, int seed, Vector2 space) {  };

    public void SignalSpawnSpheres(int amount, int seed, Vector2 space) => OnSpawnSpheres.Invoke(amount, seed, space);
    public void SignalBeginSimulation() => OnBeginSimulation.Invoke();
    public void SignalEndSimulation() => OnEndSimulation.Invoke();
}
