using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecordingData", menuName = "RecordingData")]
public class RecordingData : ScriptableObject
{
    public List<string> data = new List<string>();
    
    public void NewBallAmount(int ballAmount)
    {
        data.Add(ballAmount.ToString());
    }
    
    public void AddTime(float timeConsumption)
    {
        data[^1] += ";" + timeConsumption;
    }

    public void Reset(string firstRow)
    {
        data.Clear();
        data.Add(firstRow);
    }
}
