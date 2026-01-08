using Localhost.AI.KaonashiWeb;
using Localhost.AI.KaonashiWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Localhost.AI.KaonashiWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly OllamaService _ollamaService;
    private readonly AppConfig _config;

    public IndexModel(ILogger<IndexModel> logger, OllamaService ollamaService, AppConfig config)
    {
        _logger = logger;
        _ollamaService = ollamaService;
        _config = config;
    }

    public string[] AvailableModels { get; set; } = Array.Empty<string>();
    public bool IsConnected { get; set; }
    public AppConfig Config => _config;

    public async Task OnGetAsync()
    {
        try
        {
            IsConnected = await _ollamaService.TestConnectionAsync();
            if (IsConnected)
            {
                AvailableModels = await _ollamaService.GetAvailableModelsAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading models");
            IsConnected = false;
        }
    }
}
