using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ReSharper disable SwitchStatementMissingSomeCases

namespace DR_Downloader_DEMO.Helpers
{
    public sealed class ClipBoardMonitor : NativeWindow
    {
        // ReSharper disable InconsistentNaming
        private const int WM_DESTROY = 0x2;
        private const int WM_DRAWCLIPBOARD = 0x308;
        private const int WM_CHANGECBCHAIN = 0x30d;

        [DllImport("user32.dll")]
        private static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("user32.dll")]
        private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public event NewUrlHandler NewUrl;

        public delegate void NewUrlHandler(string url);

        private IntPtr NextClipBoardViewerHandle;

        private ClipBoardMonitor()
        {
            CreateHandle(new CreateParams());
            NextClipBoardViewerHandle = SetClipboardViewer(Handle);
        }

        private static ClipBoardMonitor instance;
        public static ClipBoardMonitor Instance { get; } = instance ?? (instance = new ClipBoardMonitor());

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (Clipboard.ContainsText())
                        NewUrl?.Invoke(Clipboard.GetText());

                    SendMessage(NextClipBoardViewerHandle, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam.Equals(NextClipBoardViewerHandle))
                        NextClipBoardViewerHandle = m.LParam;
                    else if (!NextClipBoardViewerHandle.Equals(IntPtr.Zero))
                        SendMessage(NextClipBoardViewerHandle, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_DESTROY:
                    ChangeClipboardChain(Handle, NextClipBoardViewerHandle);
                    break;
            }

            base.WndProc(ref m);
        }
    }
}