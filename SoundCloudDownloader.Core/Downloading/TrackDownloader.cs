﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gress;
using SoundCloudExplode;
using SoundCloudExplode.Tracks;

namespace SoundCloudDownloader.Core.Downloading;

public class TrackDownloader(string? clientId)
{
    private readonly SoundCloudClient _soundcloud = new(clientId ?? string.Empty);

    public async Task DownloadAsync(
        string filePath,
        Track track,
        IProgress<Percentage>? progress = null,
        CancellationToken cancellationToken = default
    )
    {
        var dirPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrWhiteSpace(dirPath))
            Directory.CreateDirectory(dirPath);

        await _soundcloud.DownloadAsync(
            track,
            filePath,
            progress?.ToDoubleBased(),
            null,
            cancellationToken
        );
    }
}
