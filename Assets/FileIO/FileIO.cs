using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileIO
{
    public string Directory = "Data/";
    private const string EXTENSION = ".csv";
    
    public void SaveFile(RecordingData data)
    {
        string fileName = data.AlgorithmName + " " + DateTime.Now + EXTENSION;
        
        using (StreamWriter writer = File.CreateText(Directory))
        {
            foreach (string entry in data.data)
            {
                writer.WriteLine(entry); //TODO: aahhhh where is the comma separator ??
            }
        }
    }
}
