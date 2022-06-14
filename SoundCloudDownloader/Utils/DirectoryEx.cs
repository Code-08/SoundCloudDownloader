﻿using System.IO;

namespace SoundCloudDownloader.Utils;

internal static class DirectoryEx
{
    public static void CreateDirectoryForFile(string filePath)
    {
        var dirPath = Path.GetDirectoryName(filePath);
        if (string.IsNullOrWhiteSpace(dirPath))
            return;

        Directory.CreateDirectory(dirPath);
    }
}