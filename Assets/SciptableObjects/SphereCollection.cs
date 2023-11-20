using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SphereCollection", menuName = "SphereCollection")]
public class SphereCollection : ScriptableObject {
    public SphereBehaviour[] Behaviours;
}
