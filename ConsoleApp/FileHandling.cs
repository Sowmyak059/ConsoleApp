using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainProject;

public class FileHandling
{
    //Methods for writing to and reading from files.The files will be saved in the current directory.
    public string FileName { get; set; }
    public string Dir { get; set; }
    public FileHandling(string fileName)
    {
        FileName = fileName;
        Dir=Directory.GetCurrentDirectory();
    }  
    public void SaveToFile(List<string> linesToSave)
    {//wrinting strings to a file
        string path = Path.Combine(Dir, FileName);
        FileInfo fileInfo = new FileInfo(path);
        //delete the file if it exists
        if (fileInfo.Exists) 
        {
            fileInfo.Delete();
        }
        //Creates a new file and writes to it
        using (StreamWriter sw = fileInfo.CreateText())
        {
            foreach (string line in linesToSave)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }
    }
    public List<string> LoadData()
    {
        Console.WriteLine("LoadData");
        string line = string.Empty;
        List<string> lines= new List<string>();
        if (!File.Exists(FileName)) return lines;

        using (StreamReader reader = new StreamReader(FileName))
        {
            while ((line = reader.ReadLine()) is not null)
            {
                var parts = line.Split('|');
                lines.Add(line);
            }
        }
        return lines;
    }
}