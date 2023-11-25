using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortingAlgorithm : MonoBehaviour {
    public abstract List<SphereBehaviour> Sort(List<SphereBehaviour> distances);
}
