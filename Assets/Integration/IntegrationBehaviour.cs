using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class IntegrationBehaviour : MonoBehaviour
{
    private List<SphereBehaviour> spheres = null;

    public void OnIntegration() {
        Profiler.BeginSample("Integration", this);
        //integrationPort.SignalBeginIntegration();
    }
}
