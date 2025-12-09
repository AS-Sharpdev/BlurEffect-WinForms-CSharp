using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlurEffect
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Holds information about how the window should handle blur/transparent effects.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct AccentPolicy
        {
            public int AccentState;   // Type of blur/accent effect
            public int AccentFlags;   // Additional options (usually unused for blur)
            public int GradientColor; // Can be used for tinting the blur (ARGB format)
            public int AnimationId;   // Reserved for animations
        }

        /// <summary>
        /// Structure used to pass data into the Windows API for setting window composition attributes.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowCompositionAttributeData
        {
            public int Attribute;     // The type of window composition attribute
            public IntPtr Data;       // Pointer to AccentPolicy data
            public int SizeOfData;    // Size of AccentPolicy structure
        }

        /// <summary>
        /// External call to user32.dll that allows setting advanced window composition attributes
        /// such as blur or acrylic effects.
        /// </summary>
        /// <param name="hwnd">Handle to the form (window)</param>
        /// <param name="data">Reference to the attribute data</param>
        /// <returns>0 on failure, non-zero on success</returns>
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(
            IntPtr hwnd,
            ref WindowCompositionAttributeData data
        );

        public Form1()
        {
            InitializeComponent();

            // Set background color (important for blur effect to show properly)
            this.BackColor = Color.Black;
             
            this.Opacity = 0.95;

            // Apply blur once the form is fully loaded
            this.Load += (s, e) => EnableBlur();
        }

        /// <summary>
        /// Enables a blur background effect for the current form.
        /// </summary>
        private void EnableBlur()
        {
            // Define blur settings
            var accent = new AccentPolicy
            {
                AccentState = 3 // ACCENT_ENABLE_BLURBEHIND = 3
            };

            // Marshal the AccentPolicy struct to unmanaged memory
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            // Prepare the composition attribute data
            var data = new WindowCompositionAttributeData
            {
                Attribute = 19,              // WCA_ACCENT_POLICY = 19
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            // Apply the blur effect to the form
            SetWindowCompositionAttribute(this.Handle, ref data);

            // Free allocated memory
            Marshal.FreeHGlobal(accentPtr);
        }
    }
}
