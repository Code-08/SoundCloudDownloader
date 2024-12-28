﻿using System;
using System.IO;
using System.Text.Json.Serialization;
using Cogwheel;
using CommunityToolkit.Mvvm.ComponentModel;
using SoundCloudDownloader.Framework;

namespace SoundCloudDownloader.Services;

// Can't use [ObservableProperty] here because System.Text.Json's source generator doesn't see
// the generated properties.
[INotifyPropertyChanged]
public partial class SettingsService()
    : SettingsBase(
        Path.Combine(AppContext.BaseDirectory, "Settings.dat"),
        SerializerContext.Default
    )
{
    private ThemeVariant _theme;
    public ThemeVariant Theme
    {
        get => _theme;
        set => SetProperty(ref _theme, value);
    }

    private bool _isAutoUpdateEnabled = true;
    public bool IsAutoUpdateEnabled
    {
        get => _isAutoUpdateEnabled;
        set => SetProperty(ref _isAutoUpdateEnabled, value);
    }

    private bool _shouldInjectTags = true;
    public bool ShouldInjectTags
    {
        get => _shouldInjectTags;
        set => SetProperty(ref _shouldInjectTags, value);
    }

    private bool _shouldSkipExistingFiles;
    public bool ShouldSkipExistingFiles
    {
        get => _shouldSkipExistingFiles;
        set => SetProperty(ref _shouldSkipExistingFiles, value);
    }

    private string _fileNameTemplate = "$title";
    public string FileNameTemplate
    {
        get => _fileNameTemplate;
        set => SetProperty(ref _fileNameTemplate, value);
    }

    private int _parallelLimit = 5;
    public int ParallelLimit
    {
        get => _parallelLimit;
        set => SetProperty(ref _parallelLimit, value);
    }

    private string _lastContainer = "Mp3";

    public string LastContainer
    {
        get => _lastContainer;
        set => SetProperty(ref _lastContainer, value);
    }
}

public partial class SettingsService
{
    [JsonSerializable(typeof(SettingsService))]
    private partial class SerializerContext : JsonSerializerContext;
}
