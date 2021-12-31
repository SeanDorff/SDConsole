namespace SDConsole
{
    internal struct SCursorState
    {
        private readonly ConsoleColor _backgroundColor;
        private readonly int _cursorLeft;
        private readonly int? _cursorSize;
        private readonly int _cursorTop;
        private readonly bool? _cursorVisible;
        private readonly ConsoleColor _foregroundColor;

        internal SCursorState(ConsoleColor backgroundColor, int cursorLeft, int? cursorSize, int cursorTop, bool? cursorVisible, ConsoleColor foregroundColor)
        {
            _backgroundColor = backgroundColor;
            _cursorLeft = cursorLeft;
            _cursorSize = cursorSize;
            _cursorTop = cursorTop;
            _cursorVisible = cursorVisible;
            _foregroundColor = foregroundColor;
        }

        internal void Deconstruct(out ConsoleColor backgroundColor, out int cursorLeft, out int? cursorSize, out int cursorTop, out bool? cursorVisible, out ConsoleColor foregroundColor)
        {
            backgroundColor = _backgroundColor;
            cursorLeft = _cursorLeft;
            cursorSize = _cursorSize;
            cursorTop = _cursorTop;
            cursorVisible = _cursorVisible;
            foregroundColor = _foregroundColor;
        }
    }
}
