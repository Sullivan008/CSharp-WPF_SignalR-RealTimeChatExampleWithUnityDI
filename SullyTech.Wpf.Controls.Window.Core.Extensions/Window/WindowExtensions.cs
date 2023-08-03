using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SullyTech.Wpf.Controls.Window.Core.Extensions.Window;

public static class WindowExtensions
{
    private const int SWP_NO_SIZE = 0x0001;
    private const int SWP_NO_MOVE = 0x0002;
    private const int SWP_NO_Z_ORDER = 0x0004;
    private const int SWP_FRAME_CHANGED = 0x0020;
    private const int GWL_EX_STYLE = -20;
    private const int WS_EX_DLG_MODAL_FRAME = 0x0001;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, uint flags);

    public static void HideIcon(this Core.Window window)
    {
        if (window.IsInitialized)
        {
            window.Icon = BitmapSource.Create(1, 1, 96, 96, PixelFormats.Bgra32, null, new byte[] { 0, 0, 0, 0 }, 4);
        }
        else
        {
            window.SourceInitialized += (_, _) =>
            {
                IntPtr hWnd = new WindowInteropHelper(window).Handle;

                int extendedStyle = GetWindowLong(hWnd, GWL_EX_STYLE);
                SetWindowLong(hWnd, GWL_EX_STYLE, extendedStyle | WS_EX_DLG_MODAL_FRAME);

                SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0,
                    SWP_NO_MOVE | SWP_NO_SIZE | SWP_NO_Z_ORDER | SWP_FRAME_CHANGED);
            };
        }
    }
}