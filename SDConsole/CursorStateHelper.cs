using System.Runtime.Versioning;

namespace SDConsole
{
    internal static class CursorStateHelper
    {
        private static readonly bool isWindows = OperatingSystem.IsWindows();

        internal static SCursorState GetCursorState()
        {
            if (isWindows)
                return GetCursorStateWindows();
            else
                return GetCursorStateOtherOS();
        }

        internal static void SetCursorState(SCursorState cursorState)
        {
            if (isWindows)
                SetCursorStateWindows(cursorState);
            else
                SetCursorStateOtherOS(cursorState);
        }

        [SupportedOSPlatformGuard("windows")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Check platform compatibility", Justification = "Different method for non-Windows OS")]
        internal static SCursorState GetCursorStateWindows() => new(Console.BackgroundColor, Console.CursorLeft, Console.CursorSize, Console.CursorTop, Console.CursorVisible, Console.ForegroundColor);
        [UnsupportedOSPlatformGuard("windows")]
        internal static SCursorState GetCursorStateOtherOS() => new(Console.BackgroundColor, Console.CursorLeft, null, Console.CursorTop, null, Console.ForegroundColor);

        [SupportedOSPlatformGuard("windows")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Check platform compatibility", Justification = "Different method for non-Windows OS")]
        internal static void SetCursorStateWindows(SCursorState cursorState)
        {
            (Console.BackgroundColor, Console.CursorLeft, int? size, Console.CursorTop, bool? visible, Console.ForegroundColor) = cursorState;
            if (size != null)
                Console.CursorSize = (int)size;
            if (visible != null)
                Console.CursorVisible = (bool)visible;
        }
        [UnsupportedOSPlatformGuard("windows")]
        internal static void SetCursorStateOtherOS(SCursorState cursorState) => (Console.BackgroundColor, Console.CursorLeft, _, Console.CursorTop, _, Console.ForegroundColor) = cursorState;
    }
}
