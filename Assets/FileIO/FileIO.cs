using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileIO : MonoBehaviour
{
    public string Destination = "Data/";
    private const string EXTENSION = ".csv";
    
    public void SaveFile(RecordingData data)
    {
        string fileName = data.AlgorithmName + " " + DateTime.Now + EXTENSION;
        
        using (StreamWriter writer = File.CreateText(Destination))
        {
            foreach (string entry in data.data)
            {
                writer.WriteLine(entry);
            }
        }
    }
}
