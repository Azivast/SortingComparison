using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "SphereCollection", menuName = "SphereCollection")]
public class SphereCollection : ScriptableObject {
    public SphereBehaviour[] Behaviours;
    public GameObject[] GameObjects;
    public GameObject SpherePrefab;

    public void Clear(int size)
    {
        Behaviours = new SphereBehaviour[size];
        GameObjects = new GameObject[size];
    }

    public void Add(GameObject gameObject, Vector2 movementSpace, int seed, int index)
    {
        GameObjects[index] = gameObject;
        Behaviours[index] = gameObject.GetComponent<SphereBehaviour>();
        Behaviours[index].Setup(movementSpace);
    }
}
