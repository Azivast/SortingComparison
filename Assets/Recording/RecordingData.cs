using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingData : MonoBehaviour
{
    public string AlgorithmName = "null";
    public List<string> data = new List<string>();


    public void AddEntry(int ballAmount, float timeConsumption)
    {
        data.Add(ballAmount + "," + timeConsumption);
    }
}
