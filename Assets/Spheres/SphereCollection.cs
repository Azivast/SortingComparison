using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "SphereCollection", menuName = "SphereCollection")]
public class SphereCollection : ScriptableObject {
    public List<SphereBehaviour> Behaviours;
    public List<GameObject> GameObjects;
    public GameObject SpherePrefab;

    public void Clear()
    {
        Behaviours.Clear();
        GameObjects.Clear();
    }

    public void Add(GameObject gameObject, Vector2 movementSpace, int seed)
    {
        GameObjects.Add(gameObject);
        var behaviour = gameObject.GetComponent<SphereBehaviour>();
        behaviour.Setup(movementSpace);
        Behaviours.Add(behaviour);
    }
}
