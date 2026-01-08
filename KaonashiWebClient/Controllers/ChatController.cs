using Localhost.AI.KaonashiWeb.Services;
using Localhost.AI.KaonashiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Localhost.AI.KaonashiWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly OllamaService _ollamaService;
        private readonly ILogger<ChatController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatController(OllamaService ollamaService, ILogger<ChatController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _ollamaService = ollamaService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            try
            {
                // Get or create chat history from session
                var session = _httpContextAccessor.HttpContext?.Session;
                var historyJson = session?.GetString("ChatHistory");
                var history = new ChatHistory();
                
                if (!string.IsNullOrEmpty(historyJson))
                {
                    // Deserialize history if exists
                    try
                    {
                        var historyData = JsonConvert.DeserializeObject<List<ChatMessage>>(historyJson);
                        if (historyData != null)
                        {
                            foreach (var msg in historyData)
                            {
                                history.AddMessage(msg.Role, msg.Content);
                            }
                        }
                    }
                    catch
                    {
                        // If deserialization fails, start fresh
                    }
                }

                string response = string.Empty;
                await _ollamaService.SendChatMessageAsync(
                    request.Message,
                    request.Model,
                    history,
                    (chunk) => { response = chunk; },
                    request.SystemPrompt
                );

                // Save updated history to session
                var updatedHistory = new List<ChatMessage>();
                var messages = history.GetMessages();
                foreach (var msg in messages)
                {
                    var role = msg.GetType().GetProperty("role")?.GetValue(msg)?.ToString() ?? "";
                    var content = msg.GetType().GetProperty("content")?.GetValue(msg)?.ToString() ?? "";
                    if (role != "system")
                    {
                        updatedHistory.Add(new ChatMessage { Role = role, Content = content });
                    }
                }
                
                session?.SetString("ChatHistory", JsonConvert.SerializeObject(updatedHistory));

                return Ok(new { response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending chat message");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("clear")]
        public IActionResult ClearHistory()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.Remove("ChatHistory");
            return Ok(new { message = "Chat history cleared" });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? SystemPrompt { get; set; }
    }

    public class ChatMessage
    {
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}

