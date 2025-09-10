#  BlurEffect (C# WinForms)

A simple Windows Forms project that demonstrates how to enable the Windows Blur Behind effect (Aero blur / Acrylic blur) on your form using the Win32 API.

---

## 📺 YouTube Tutorial
👉 Watch the full step-by-step tutorial on YouTube:  
[![Watch the video](https://img.shields.io/badge/YouTube-Watch%20Now-red?logo=youtube&style=for-the-badge)](https://youtu.be/q09g8dlKoGM)


(Replace with your actual screenshot of the blurred form)

✨ Features

Apply Windows 10/11 blur effect to any WinForms application.

Uses the SetWindowCompositionAttribute API call from user32.dll.

Lightweight, no third-party dependencies.

Clean, commented C# source code for learning purposes.

📂 Project Structure
BlurEffect/
 ├── BlurEffect.csproj
 ├── Form1.cs        # Main form with blur logic
 ├── Program.cs      # Application entry point
 └── README.md       # Project documentation

🛠️ How It Works

The project uses a struct called AccentPolicy which defines the blur settings.
This is then passed to the SetWindowCompositionAttribute function to apply the effect.

Key values:

AccentState = 3 → Enables Blur Behind.

Attribute = 19 → Refers to WCA_ACCENT_POLICY.

The form background color is set to black so the blur is clearly visible.

▶️ Getting Started

Clone this repository:

Open the project in Visual Studio.

Build and run the solution.

You’ll see your form with a blurred background effect.



📜 License

This project is licensed under the MIT License – free to use and modify.

👨‍💻 About Me

I’m a professional developer with 15+ years of experience, passionate about C# and WinForms.
I started this GitHub to share knowledge and cool small projects with the community.
