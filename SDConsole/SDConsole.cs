using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace SDConsole
{
    /// <summary>
    /// Static class for managing the console state.
    /// It is a wrapper arount <see cref="System.Console"/>.
    /// </summary>
    public static class SDConsole
    {
        private static readonly ConcurrentStack<SCursorState> cursorStateStack = new();
        private static readonly bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        private static readonly object cursorStateLock = new();

        public static void PushCursorState() => cursorStateStack.Push(GetCursorState());

        public static void PopCursorState()
        {
            SCursorState cursorState;
            if (cursorStateStack.TryPop(out cursorState))
                SetCursorState(cursorState);
        }

        public static object GetCursorStateLock() => cursorStateLock;

        private static SCursorState GetCursorState() => new(Console.BackgroundColor, Console.CursorLeft, Console.CursorSize, Console.CursorTop, isWindows && Console.CursorVisible, Console.ForegroundColor);

        private static void SetCursorState(SCursorState cursorState)
        {
            (Console.BackgroundColor, Console.CursorLeft, Console.CursorSize, Console.CursorTop, bool cursorVisible, Console.ForegroundColor) = cursorState;
            if (isWindows)
                Console.CursorVisible = cursorVisible;
        }
    }
}