using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

public class CopyUtil
{
    private string SourcePath { get; set; }
    private string DestinationPath { get; set; }
    public CopyUtil(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public void CopyModifiedFiles()
    {
        if (!Directory.Exists(SourcePath) || !Directory.Exists(DestinationPath))
            return;

        var lastIndexSourcePath = SourcePath.Length - 1;

        var sourceDlls = Directory.GetFiles(SourcePath, "*.dll", SearchOption.AllDirectories).ToDictionary(key => key.Substring(lastIndexSourcePath));

        var lastIndexDestinationPath = DestinationPath.Length - 1;

        var destinationDlls = Directory.GetFiles(DestinationPath, "*.dll", SearchOption.AllDirectories).ToDictionary(key => key.Substring(lastIndexDestinationPath), val => val);

        // HashSet<string> destinationPdbs = Directory.GetFiles(DestinationPath, "*.pdb", SearchOption.AllDirectories).ToHashSet();

        foreach (var dll in sourceDlls)
        {
            if (destinationDlls.TryGetValue(dll.Key, out string destinationDllPath))
            {
               var isSame = IsFilesSame(dll.Value, destinationDllPath);
            }
        }
    }

    public static bool IsFilesAreSame(string sourcePath, string destinationPath)
    {
        var sourceHash = CalculateMD5(sourcePath);
        var destinationHash = CalculateMD5(destinationPath);

        bool isSame = (sourceHash == destinationHash);

        return isSame;
    }

    static string CalculateMD5(string filename)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }


    }

    static bool IsFilesSame(string sourcePath, string destinationPath)
    {

        FileInfo f1 = new FileInfo(sourcePath);
        FileInfo f2 = new FileInfo(destinationPath);

        // checking the size of files
        bool isSame = (f1.Length == f2.Length);

        return isSame;

    }

}