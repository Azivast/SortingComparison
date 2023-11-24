using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperminetBehaviour : MonoBehaviour
{
    [SerializeField] private ExperimentPort experimentPort;
    [SerializeField] private int numberOfSpheres = 20;
    [SerializeField] private int sphereIncrease = 20;
    [SerializeField] private int spheresToHighlight = 10;
    [SerializeField] private Vector2 simulationSpaceSize = new Vector2(8, 4);
    [SerializeField] private int seed = 1234567;
    
    [SerializeField] private int sampleRate = 10;
    [SerializeField] private float cancelTime= 1.0f;


    [SerializeField] private List<SortingAlgorithm> Algorithms;
    
    


}
