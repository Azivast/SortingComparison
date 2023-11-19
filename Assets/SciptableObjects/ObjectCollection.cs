using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObjectCollection", menuName = "ObjectCollection")]
public class ObjectCollection : ScriptableObject {
    public List<GameObject> gameObjects = new List<GameObject>();
}
