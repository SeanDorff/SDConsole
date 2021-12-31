using SDConsole.WriteBuffer;

using System.Collections.Concurrent;

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
            Console.WriteLine();
        }

        /// <summary>
        /// Returns the lock object for convenient synchronization.
        /// </summary>
        /// <returns></returns>
        public static object GetCursorStateLock() => cursorStateLock;

        public static void Write(bool value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(char value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(char[]? buffer) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, buffer));
        public static void Write(char[] buffer, int index, int count) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, buffer, index, count));
        public static void Write(decimal value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(double value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(int value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(long value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(object? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(float value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(string? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(string format, object? arg0) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0));
        public static void Write(string format, object? arg0, object? arg1) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0, arg1));
        public static void Write(string format, object? arg0, object? arg1, object? arg2) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg0, arg1, arg2));
        public static void Write(string format, params object?[]? arg) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, format, arg));
        public static void Write(uint value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void Write(ulong value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(false, value));
        public static void WriteLine() => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, ""));
        public static void WriteLine(bool value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(char value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(char[]? buffer) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, buffer));
        public static void WriteLine(char[] buffer, int index, int count) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, buffer, index, count));
        public static void WriteLine(decimal value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(double value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(int value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(long value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(object? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(float value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(string? value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(string format, object? arg0) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0));
        public static void WriteLine(string format, object? arg0, object? arg1) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0, arg1));
        public static void WriteLine(string format, object? arg0, object? arg1, object? arg2) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg0, arg1, arg2));
        public static void WriteLine(string format, params object?[]? arg) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, format, arg));
        public static void WriteLine(uint value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
        public static void WriteLine(ulong value) => WriteBufferWriter.Enqueue(new WriteBufferContainer(true, value));
    }
}