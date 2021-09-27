using System.IO;
using UnityEngine;

[System.Serializable]
public class FileManagement : MonoBehaviour
{
    public static void CreateDirectory(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        if (Directory.Exists(directoryPath))
        {
            Debug.Log("Directory \"" + directoryPath + "\" created succesfully!");
        }
    }

    public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the destination directory doesn't exist, create it.       
        Directory.CreateDirectory(destDirName);

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string tempPath = Path.Combine(destDirName, file.Name);
            file.CopyTo(tempPath, true);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
            }
        }
    }

    public static bool CheckExtensions(string path, string[] extensions)
    {
        if (path != null && extensions.Length > 0)
        {
            string pathExt = Path.GetExtension(path);

            foreach (string extension in extensions)
            {
                if (pathExt.ToLower() == extension.ToLower())
                    return true;
            } 
        }
        return false;
    }
}
