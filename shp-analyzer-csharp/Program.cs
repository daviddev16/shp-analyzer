using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {

        Console.Title = "Analisador de pacotes de integração SHP";

        string entryFolder = (args.Length > 0) ? args[0] : null;

        while (entryFolder == null || !Directory.Exists(entryFolder)) 
        {
            Console.Write("\n Pasta com os pacotes: ");
            entryFolder = Console.ReadLine();
        }

        Console.WriteLine("\n");
        Analyze(entryFolder);
        Console.WriteLine("\n");
        Console.ReadKey();

    }

    public static void Analyze(string entryFolder)
    {
        int fileCount = 0;
        Stopwatch sw = new Stopwatch();
        List<string> corruptedFiles = new List<string>();
        Console.WriteLine("\n");
        sw.Start();
        foreach (string filepath in Directory.GetFiles(entryFolder, "*", SearchOption.AllDirectories)) 
        {
            fileCount++;
            if (!CanOpenFile(filepath))
                corruptedFiles.Add(filepath);
        }
        sw.Stop();
        Console.Clear();
        Console.WriteLine("\n");
        corruptedFiles.ForEach(filepath => Console.WriteLine("ERRO: \"" + filepath + "\""));
        Console.WriteLine("\nForam analisados " + fileCount + " arquivos em " + sw.ElapsedMilliseconds + "ms.");
    }

    public static bool CanOpenFile(string filepath)
    {
        try {
            ZipArchive archive = ZipFile.OpenRead(filepath);
            archive.Dispose();
            return true;
        } catch (Exception)
        {
            return false;
        }
    }

}
