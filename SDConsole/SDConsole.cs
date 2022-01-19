using SDConNS.WriteBuffer;

using System.Collections.Concurrent;

namespace SDConNS
{
    /// <summary>
    /// Static class for managing the console state.
    /// It is a wrapper arount <see cref="System.Console"/>.
    /// </summary>
    public static class SDConsole
    {
        private static readonly ConcurrentStack<SCursorState> cursorStateStack = new();
        private static readonly object cursorStateLock = new();

        /// <summary>
        /// Pushes the current cursor state on a stack.
        /// </summary>
        public static void PushCursorState() => cursorStateStack.Push(CursorStateHelper.GetCursorState());

        /// <summary>
        /// Pops the top cursor state from a stack.
        /// </summary>
        public static void PopCursorState()
        {
            if (cursorStateStack.TryPop(out SCursorState cursorState))
                CursorStateHelper.SetCursorState(cursorState);
        }

        /// <summary>
        /// Returns the lock object for convenient synchronization.
        /// </summary>
        /// <returns><see cref="object"/> cursor state lock</returns>
        public static object GetCursorStateLock() => cursorStateLock;

        /// <summary>
        /// See <see cref="Console.Write(bool)"/>
        /// </summary>
        public static void Write(bool value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(char)"/>
        /// </summary>
        public static void Write(char value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(char[]?)"/>
        /// </summary>
        public static void Write(char[]? buffer) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, buffer));
        /// <summary>
        /// See <see cref="Console.Write(char[], int, int)"/>
        /// </summary>
        public static void Write(char[] buffer, int index, int count) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, buffer, index, count));
        /// <summary>
        /// See <see cref="Console.Write(decimal)"/>
        /// </summary>
        public static void Write(decimal value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(double)"/>
        /// </summary>
        public static void Write(double value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(int)"/>
        /// </summary>
        public static void Write(int value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(long)"/>
        /// </summary>
        public static void Write(long value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(object?)"/>
        /// </summary>
        public static void Write(object? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(float)"/>
        /// </summary>
        public static void Write(float value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(string?)"/>
        /// </summary>
        public static void Write(string? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(string, object?)"/>
        /// </summary>
        public static void Write(string format, object? arg0) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0));
        /// <summary>
        /// See <see cref="Console.Write(string, object?, object?)"/>
        /// </summary>
        public static void Write(string format, object? arg0, object? arg1) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0, arg1));
        /// <summary>
        /// See <see cref="Console.Write(string, object?, object?, object?)"/>
        /// </summary>
        public static void Write(string format, object? arg0, object? arg1, object? arg2) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0, arg1, arg2));
        /// <summary>
        /// See <see cref="Console.Write(string, object?[]?)"/>
        /// </summary>
        public static void Write(string format, params object?[]? arg) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg));
        /// <summary>
        /// See <see cref="Console.Write(uint)"/>
        /// </summary>
        public static void Write(uint value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.Write(ulong)"/>
        /// </summary>
        public static void Write(ulong value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        /// <summary>
        /// See <see cref="Console.WriteLine()"/>
        /// </summary>
        public static void WriteLine() { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, "")); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(bool)"/>
        /// </summary>
        public static void WriteLine(bool value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(char)"/>
        /// </summary>
        public static void WriteLine(char value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(char[]?)"/>
        /// </summary>
        public static void WriteLine(char[]? buffer) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, buffer)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(char[], int, int)"/>
        /// </summary>
        public static void WriteLine(char[] buffer, int index, int count) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, buffer, index, count)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(decimal)"/>
        /// </summary>
        public static void WriteLine(decimal value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(double)"/>
        /// </summary>
        public static void WriteLine(double value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(int)"
        /// </summary>
        public static void WriteLine(int value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(long)"/>
        /// </summary>
        public static void WriteLine(long value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(object?)"/>
        /// </summary>
        public static void WriteLine(object? value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(float)"/>
        /// </summary>
        public static void WriteLine(float value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(string?)"/>
        /// </summary>
        public static void WriteLine(string? value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(string, object?)"/>
        /// </summary>
        public static void WriteLine(string format, object? arg0) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(string, object?, object?)"/>
        /// </summary>
        public static void WriteLine(string format, object? arg0, object? arg1) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0, arg1)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(string, object?, object?, object?)"/>
        /// </summary>
        public static void WriteLine(string format, object? arg0, object? arg1, object? arg2) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0, arg1, arg2)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(string, object?[]?)"/>
        /// </summary>
        public static void WriteLine(string format, params object?[]? arg) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(uint)"/>
        /// </summary>
        public static void WriteLine(uint value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }
        /// <summary>
        /// See <see cref="Console.WriteLine(ulong)"/>
        /// </summary>
        public static void WriteLine(ulong value) { WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value)); LineFeed(); }

        /// <summary>
        /// Set a custom thread sleep time.
        /// </summary>
        /// <param name="sleep">Thread sleep time in milliseconds</param>
        public static void SetThreadSleepTime(int sleep) => WriteBufferWriter.SetThreadSleepTime(sleep);

        /// <summary>
        /// Reset the thread sleep time to the default.
        /// </summary>
        public static void ResetThreadSleepTime() => WriteBufferWriter.ResetThreadSleepTime();

        private static void LineFeed() => Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
    }
}