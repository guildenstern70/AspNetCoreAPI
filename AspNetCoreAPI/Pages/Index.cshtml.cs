/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreApi.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    public string? Version { get; set; }
    public string? SdkVersion { get; set; }

    public void OnGet()
    {
        var versionInfo = Assembly.GetEntryAssembly()?.GetName().Version;
        this.Version = versionInfo != null ? versionInfo.ToString() : "?";
        this.SdkVersion = RuntimeInformation.FrameworkDescription;
    }
}
