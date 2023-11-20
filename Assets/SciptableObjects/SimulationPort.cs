using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SimulationPort", menuName = "SimulationPort")]
public class SimulationPort : ScriptableObject
{
    public UnityAction OnBeginFixedUpdate = delegate {};
    public UnityAction OnIntegration = delegate {};
    public UnityAction OnDetection = delegate {};
    public UnityAction OnResolution = delegate {};
    public UnityAction OnEndFixedUpdate = delegate {};

    public void SignalBeginFixedUpdate() => OnBeginFixedUpdate.Invoke();
    public void SignalIntegration() => OnIntegration.Invoke();
    public void SignalDetection() => OnDetection.Invoke();
    public void SignalResolution() => OnResolution.Invoke();
    public void SignalEndFixedUpdate() => OnEndFixedUpdate.Invoke();
}
