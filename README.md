# 🎵 Selenium YouTube Test Suite

Automated test suite using **C#**, **Selenium WebDriver**, and **NUnit** that simulates user behavior on [YouTube](https://www.youtube.com). The suite searches for a video, plays it, skips ads, and extracts the artist's name from the video description.

✅ Make sure you install the [.NET SDK](https://dotnet.microsoft.com/en-us/download) before running the automation.

## ✨ Features

- 🔍 **Search** for a music video with custom filters  
- 🎯 **Locate & Play** a specific video using its unique ID  
- ⏭️ **Skip Ads** automatically when they appear  
- 🧠 **Extract Artist Name** from the expanded video description  

✅ Supported Browsers: chrome, firefox, edge

## 🧰 Tech Stack

💻 C#

🌐 Selenium WebDriver

🧪 NUnit for test framework

## 📸 Sample Output

🎬 **Found target video:** https://www.youtube.com/watch?v=ybXrrTX3LuI

📺 **Channel:** nikki7993

🎤 **Artist Name:** Gloria Gaynor

### 🧪 Run the Project


Step 1: Restore packages
```bash
dotnet restore

# Step 2: Build the project
dotnet build

# Step 3: Run the tests
dotnet test

🧪 Step 3: Run the Test for SeleniumTests folder

```bash
dotnet test

