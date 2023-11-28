using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SimulationPort", menuName = "SimulationPort")]
public class SimulationPort : ScriptableObject
{
    public UnityAction OnBeginUpdate = delegate {};
    public UnityAction OnIntegration = delegate {};
    public UnityAction OnDetection = delegate {};
    public UnityAction OnResolution = delegate {};
    public UnityAction OnEndUpdate = delegate {};
    public UnityAction<float> OnNewFrameTime = delegate {};

    public void SignalBeginUpdate() => OnBeginUpdate.Invoke();
    public void SignalIntegration() => OnIntegration.Invoke();
    public void SignalDetection() => OnDetection.Invoke();
    public void SignalResolution() => OnResolution.Invoke();
    public void SignalEndUpdate() => OnEndUpdate.Invoke();
    public void SignalNewFrameTime(float time) => OnNewFrameTime.Invoke(time);
}
