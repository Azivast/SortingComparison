using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private SphereCollection collection;
    [SerializeField] private SphereBehaviour targetSphere;

    public void Spawn(int amount, int seed, Vector2 simulationSpace)
    {
        targetSphere.Reset();
        collection.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < amount; i++)
        {
            GameObject sphere = Instantiate(collection.SpherePrefab, Random.insideUnitCircle, Quaternion.identity, transform);
            collection.Add(sphere, simulationSpace, seed);
        }
    }
}
