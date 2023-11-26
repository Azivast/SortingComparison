using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private SphereCollection collection;
    [SerializeField] private SphereBehaviour targetSphere;

    private void OnEnable() {
        experimentPort.OnSpawnSpheres += Spawn;
    }
    private void OnDisable() {
        experimentPort.OnSpawnSpheres -= Spawn;
    }

    public void Spawn(int amount, int seed, Vector2 simulationSpace)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject sphere = Instantiate(collection.SpherePrefab, transform);
            collection.Add(sphere, simulationSpace, seed);
        }
    }

    public void Clear() 
    {
        collection.Clear();
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
