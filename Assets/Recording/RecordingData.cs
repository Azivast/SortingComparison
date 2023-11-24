using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingData : MonoBehaviour
{
    public string AlgorithmName = "";
    public List<string> data = new List<string>();


    public void AddDataEntry(string ballAmount, float timeConsumption)
    {
        data.Add(ballAmount + "," + timeConsumption);
    }
}
