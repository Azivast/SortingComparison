using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimulationPort : ScriptableObject
{
    public UnityAction OnBeginFixedUpdate;
    public UnityAction OnIntegration;
    public UnityAction OnSorting;
    public UnityAction OnResolution;
    public UnityAction OnEndFixedUpdate;

    public void SignalBeginFixedUpdate() => OnBeginFixedUpdate.Invoke();
    public void SignalIntegration() => OnIntegration.Invoke();
    public void SignalSorting() => OnSorting.Invoke();
    public void SignalResolution() => OnResolution.Invoke();
    public void SignalEndFixedUpdate() => OnEndFixedUpdate.Invoke();
}
