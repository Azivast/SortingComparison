using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileIO
{
    public string Directory = "Results/";
    private const string EXTENSION = ".csv";
    
    public bool SaveFile(RecordingData data)
    {
        string fileName = data.AlgorithmName + " " + DateTime.Now.ToString("yyyy-MM-dd hhmm") + EXTENSION;
        System.IO.Directory.CreateDirectory(Directory);
        using (StreamWriter writer = File.CreateText(Directory+fileName))
        {
            foreach (string entry in data.data)
            {
                writer.WriteLine(entry);
            }
        }
        return true;
    }

    public void VerifyWritable()
    {
        try
        {
            System.IO.Directory.CreateDirectory(Directory);
        }
        catch
        {
            throw new Exception($"Unable to write to data path {Directory}. Experiment will not be run.");
        }
    }
}
