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

💡 Usage Example

If you just want to add blur to any form in your own project, copy this helper method and call it in your form’s Load event:

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class BlurHelper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AccentPolicy
    {
        public int AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WindowCompositionAttributeData
    {
        public int Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

    public static void EnableBlur(Form form, int accentState = 3)
    {
        var accent = new AccentPolicy { AccentState = accentState };

        var size = Marshal.SizeOf(accent);
        var ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(accent, ptr, false);

        var data = new WindowCompositionAttributeData
        {
            Attribute = 19, // WCA_ACCENT_POLICY
            SizeOfData = size,
            Data = ptr
        };

        SetWindowCompositionAttribute(form.Handle, ref data);
        Marshal.FreeHGlobal(ptr);
    }
}



Then, in your form:

public Form1()
{
    InitializeComponent();
    this.Load += (s, e) => BlurHelper.EnableBlur(this, 3); // 3 = Blur Behind
}


🎨 AccentState Values

You can experiment with different AccentState values to get different visual effects:

Value	Name	Effect
0	ACCENT_DISABLED	No effect (default window background).
1	ACCENT_ENABLE_GRADIENT	Applies a solid or gradient color fill.
2	ACCENT_ENABLE_TRANSPARENTGRADIENT	Makes the background partially transparent.
3	ACCENT_ENABLE_BLURBEHIND	Classic Aero blur effect (Windows 7/10 style).
4	ACCENT_ENABLE_ACRYLICBLURBEHIND	Modern Acrylic blur (Windows 10/11, semi-transparent with tint).
5	ACCENT_ENABLE_HOSTBACKDROP	Uses host backdrop for blur (newer Windows builds only).
6	ACCENT_INVALID_STATE	Not valid (reserved).

👉 Try replacing 3 with 4 in the helper method to test Acrylic blur instead of normal blur.


🤝 Contributing

Pull requests are welcome! If you have suggestions for improvements (e.g., supporting more effects), feel free to contribute.

📜 License

This project is licensed under the MIT License – free to use and modify.

👨‍💻 About Me

I’m a professional developer with 15+ years of experience, passionate about C# and WinForms.
I started this GitHub to share knowledge and cool small projects with the community.
