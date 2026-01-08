# Quick Start Guide - Ollama Chatbot

Get up and running with the Ollama Chatbot in just a few minutes!

## Step 1: Install Prerequisites

### Install Ollama
1. Download Ollama from https://ollama.ai
2. Install and run Ollama
3. Pull a model (in terminal/PowerShell):
   ```bash
   ollama pull llama2
   ```

### Install .NET 8.0 SDK
Download from: https://dotnet.microsoft.com/download/dotnet/8.0

## Step 2: Build and Run

### Option A: Run from source (Development)
```bash
cd OllamaChatbot
dotnet restore
dotnet run
```

### Option B: Build executable (Production)
```bash
cd OllamaChatbot
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
Executable location: `bin/Release/net8.0-windows/win-x64/publish/OllamaChatbot.exe`

## Step 3: First Launch

1. The app will automatically try to connect to `localhost:11434`
2. If successful, you'll see a green "Connected" status
3. Select a model from the dropdown
4. Start chatting!

## Using the App

### Send a Message
- Type in the text box at the bottom
- Press **Ctrl+Enter** or click **Send ➤**
- Use **UP arrow** to recall previous prompts
- Watch the response stream in real-time

### Change Settings
1. Click **⚙ Settings**
2. Modify host/port if Ollama is on a different machine
3. Customize the **System Prompt** to define AI behavior:
   - "You are a helpful coding assistant."
   - "You are a creative writer who uses metaphors."
   - "You are a concise business analyst."
4. Check/uncheck **Hide <think> tags** to filter AI reasoning tokens
5. Click **Save**

### Clear History
- Click **🗑 Clear** to start a fresh conversation

## Troubleshooting

### Can't Connect?
```bash
# Make sure Ollama is running
ollama serve
```

### No Models?
```bash
# Pull a model first
ollama pull llama2
ollama pull mistral
ollama pull codellama
```

### Port Already in Use?
In Settings, change the port to match your Ollama configuration.

## Tips

- Use **Ctrl+Enter** for quick message sending
- Use **UP/DOWN arrows** to navigate through your previous prompts (like terminal history)
- The connection indicator (colored dot) shows status at a glance:
  - 🟢 Green: Connected and ready
  - 🟠 Orange: Connecting or no models
  - 🔴 Red: Connection error
  - 🟣 Purple: Processing message
- Chat history is maintained during the session for context-aware conversations
- Prompt history is also saved so you can recall previous questions
- Settings are automatically saved between sessions
- **System Prompt** is applied to every message, so you can customize the AI's personality and expertise

## Enjoy!

You're all set! Start having conversations with your local AI models.

For more details, see [README.md](OllamaChatbot/README.md)

