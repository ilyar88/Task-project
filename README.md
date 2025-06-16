# 🎵 Selenium YouTube Test Suite

Automated test suite using **C#**, **Selenium WebDriver**, and **NUnit** that simulates user behavior on [YouTube](https://www.youtube.com). The suite searches for a video, plays it, skips ads, and extracts the artist's name from the video description.

---

## ✨ Features

- 🔍 **Search** for a music video with custom filters  
- 🎯 **Locate & Play** a specific video using its unique ID  
- ⏭️ **Skip Ads** automatically when they appear  
- 🧠 **Extract Artist Name** from the expanded video description  

---

## ⚙️ Configuration

Edit the XML config at: `configuration/data.xml`

```xml
<Settings>
  <Browser>chrome</Browser>
  <WaitTime>10</WaitTime>
  <Url>https://www.youtube.com/</Url>
</Settings>
