# 🎵 Selenium YouTube Test Suite

This project automates interaction with **YouTube** using **Selenium WebDriver** in C#. It simulates user actions such as searching for a video, playing a specific video, skipping ads, and extracting the artist name from the video description.

### 🚀 Features

- ✅ Search for a YouTube video
- 🎯 Locate and play a specific video using its ID
- ⏭️ Automatically skip ads
- 🧠 Extract the artist's name from the description

## 🧪 Test Scenarios

1. **SearchForSong** - Searches for a music video with filters.
2. **FindAndPlaySpecificVideo** - Identifies and plays a target video by ID.
3. **FindArtistName** - Expands the description and extracts the artist’s name.

## ⚙️ Configuration

Modify `configuration/data.xml` to customize:

```xml
<Settings>
  <Browser>chrome</Browser>
  <WaitTime>10</WaitTime>
  <Url>https://www.youtube.com/</Url>
</Settings>
Supported browsers: chrome, firefox, edge.

🧰 Tech Stack

**C#**
- **Selenium WebDriver**
- **NUnit**
- **WebDriverManager**

📸 Sample Output

Found target video: https://www.youtube.com/watch?v=ybXrrTX3LuI
user/channel: GloriaGaynorMusic
The artist name is: Gloria Gaynor
💡 How to Run
Make sure you have .NET and your desired browser installed.

Restore dependencies and build:

dotnet restore
dotnet build

Run tests:
dotnet test



