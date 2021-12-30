using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace SDConsole
{
    /// <summary>
    /// Static class for managing the console state.
    /// It is a wrapper arount <see cref="System.Console"/>.
    /// </summary>
    public static class SDConsole
    {
        private static readonly ConcurrentStack<SCursorState> cursorStateStack = new();
        private static readonly object cursorStateLock = new();
        private static readonly bool isWindows = OperatingSystem.IsWindows();

        public static void PushCursorState()
        {
            if (isWindows)
                cursorStateStack.Push(GetCursorStateWindows());
            else
                cursorStateStack.Push(GetCursorStateOtherOS());
        }

        public static void PopCursorState()
        {
            SCursorState cursorState;
            if (cursorStateStack.TryPop(out cursorState))
                if (isWindows)
                    SetCursorStateWindows(cursorState);
                else
                    SetCursorStateOtherOS(cursorState);
        }

        public static object GetCursorStateLock() => cursorStateLock;

        [SupportedOSPlatformGuard("windows")]
        private static SCursorState GetCursorStateWindows() => new(Console.BackgroundColor, Console.CursorLeft, Console.CursorSize, Console.CursorTop, Console.CursorVisible, Console.ForegroundColor);
        [UnsupportedOSPlatformGuard("windows")]
        private static SCursorState GetCursorStateOtherOS() => new(Console.BackgroundColor, Console.CursorLeft, -1, Console.CursorTop, false, Console.ForegroundColor);

        [SupportedOSPlatformGuard("windows")]
        private static void SetCursorStateWindows(SCursorState cursorState) => (Console.BackgroundColor, Console.CursorLeft, Console.CursorSize, Console.CursorTop, Console.CursorVisible, Console.ForegroundColor) = cursorState;
        [UnsupportedOSPlatformGuard("windows")]
        private static void SetCursorStateOtherOS(SCursorState cursorState) => (Console.BackgroundColor, Console.CursorLeft, _, Console.CursorTop, _, Console.ForegroundColor) = cursorState;

    }
}