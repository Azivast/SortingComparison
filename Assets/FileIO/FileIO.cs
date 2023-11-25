using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileIO
{
    public string Directory = "Results/";
    private const string EXTENSION = ".csv";
    
    public void SaveFile(RecordingData data)
    {
        string fileName = data.AlgorithmName + " " + DateTime.Now + EXTENSION;
        System.IO.Directory.CreateDirectory(Directory);
        using (StreamWriter writer = File.CreateText(Directory+fileName))
        {
            foreach (string entry in data.data)
            {
                writer.WriteLine(entry); //TODO: aahhhh where is the comma separator ??
            }
        }
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
