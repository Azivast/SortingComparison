using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileIO
{
    private const string EXTENSION = ".csv";
    
    public bool SaveFile(RecordingData data)
    {
        string fileName = DateTime.Now.ToString("yyyy-MM-dd HHmmss") + EXTENSION;
        using (StreamWriter writer = File.CreateText(fileName))
        {
            foreach (string entry in data.data)
            {
                writer.WriteLine(entry);
            }
        }
        return true;
    }
}
