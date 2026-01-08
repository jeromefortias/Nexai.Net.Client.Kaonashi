# Changelog

All notable changes to the Ollama Chatbot project will be documented in this file.

## [2.3.0] - Think Tag Filtering & Marvin Image

### Added
- **Hide Think Tags Option**: New checkbox in settings to filter out `<think>...</think>` tags from AI responses
- **Think Tag Regex Filter**: Automatically removes reasoning tokens when enabled (default: on)
- **Marvin Background Image**: Character image displayed on the right side of the chat
- **Dynamic Marvin Eyes**: Eyes overlay that changes based on conversation sentiment
  - Default: `marvin-normal-eyes.png`
  - Happy mode: `marvin-happy-eyes.png` (triggers on keywords: "happy", "fun", "great")
- **Image Panel**: 305px panel on the right showing Marvin character with layered images
- **Emotion Detection**: Real-time keyword detection in AI responses to change expressions
- Wider window layout (1300px) to accommodate image panel

### Changed
- Settings dialog expanded to 580px height for new checkbox
- Main window increased from 1000px to 1300px width
- Chat panel limited to left side (950px wide)
- Input panel spans full width
- Image panel now supports multiple overlaid PictureBoxes

## [2.2.0] - Prompt History Navigation

### Added
- **UP/DOWN Arrow Navigation**: Navigate through previous prompts using arrow keys
- **Prompt History Tracking**: All sent messages are stored for easy recall
- **Terminal-like Experience**: Works like command history in terminal/PowerShell
- Cursor automatically positions at end of recalled message
- History clears when chat is cleared

### Changed
- KeyDown handler now supports UP and DOWN arrow keys
- Message history maintained in MainForm as List<string>

## [2.1.0] - System Prompt Support

### Added
- **System Prompt Configuration**: New multiline textbox in settings to define AI behavior
- **Custom AI Personality**: System prompt is sent with every message to maintain consistent behavior
- **Validation**: Ensures system prompt is not empty before saving

### Changed
- Settings dialog expanded to accommodate system prompt field (520px height)
- AppConfig now includes SystemPrompt field with default value
- ChatHistory class updated to inject system prompt as first message
- OllamaService.SendChatMessageAsync now accepts optional systemPrompt parameter

## [2.0.0] - Modern UI Update

### Added
- **Modern Dark Theme**: Complete UI overhaul with Discord-inspired dark color palette
- **Connection Status Indicator**: Visual colored dot showing real-time connection status
- **Panel-based Layout**: Organized interface with header, content, input, and footer panels
- **Hover Effects**: Smooth button hover animations for better interactivity
- **Color-Coded Messages**: Visual distinction between You (purple), Assistant (green), and System (gray)
- **Enhanced Status Messages**: Icons and emojis for better visual feedback
- **Improved Typography**: Better font sizes and weights for readability
- **Footer Bar**: Helpful shortcuts and tips always visible

### Changed
- **Color Scheme**: 
  - Background: Dark gray (#363941)
  - Secondary panels: Darker gray (#2F3136)
  - Input areas: Medium gray (#40444B)
  - Primary buttons: Purple (#5865F2)
  - Success: Green (#43B581)
  - Warning: Orange (#FAA61A)
  - Error: Red (#ED4245)
- **Button Styles**: Flat design with no borders, modern look
- **Text Colors**: Light gray (#DCDCDE) for better contrast on dark background
- **Window Size**: Increased to 1000x700 for better visibility (was 800x600)
- **Settings Dialog**: Redesigned with matching dark theme and better organization

### Improved
- **Chat Display**: Better padding, borderless design for seamless look
- **Input Box**: Larger, borderless input with better contrast
- **Send Button**: More prominent with arrow icon "Send ➤"
- **Status Updates**: Real-time color changes for connection status
- **Message Headers**: Bullet points (●) for cleaner message separation
- **System Messages**: Smaller, italic, gray text with icons

### Fixed
- Layout anchoring for proper window resizing
- Font consistency across all UI elements
- Button hover states now provide visual feedback

## [1.0.0] - Initial Release

### Added
- Basic Windows Forms UI
- Ollama API integration
- Streaming chat responses
- Model selection
- Settings configuration
- Chat history management
- Configuration persistence

