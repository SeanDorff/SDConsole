using SDConsole.Enums;

namespace SDConsole.WriteBuffer
{
    public class WriteBufferContainer
    {
        private readonly EWriteBufferType _writeBufferType;
        private readonly SCursorState _cursorState = CursorStateHelper.GetCursorState();
        private readonly object _value0;
        private readonly object? _nullableValue0;
        private readonly object? _nullableValue1;
        private readonly object? _nullableValue2;
        private readonly object?[]? _nullableObjectNullableArray;

        private readonly int _index;
        private readonly int _count;

        private readonly bool _isWriteLine;

        private static readonly object _placeHolder = new();

        internal EWriteBufferType WriteBufferType => _writeBufferType;
        internal SCursorState CursorState => _cursorState;

        internal bool IsWriteLine => _isWriteLine;

        internal WriteBufferContainer(bool isWriteLine, bool value)
        {
            _writeBufferType = EWriteBufferType.Bool;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal bool GetValueBool() => (bool)_value0;

        internal WriteBufferContainer(bool isWriteLine, char value)
        {
            _writeBufferType = EWriteBufferType.Char;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal char GetValueChar() => (char)_value0;

        internal WriteBufferContainer(bool isWriteLine, char[]? value)
        {
            _writeBufferType = EWriteBufferType.NullableCharArray;
            _nullableValue0 = value;
            _value0 = _placeHolder;
            _isWriteLine = isWriteLine;
        }

        internal char[]? GetValueNullableCharArray() => (char[]?)_nullableValue0;

        internal WriteBufferContainer(bool isWriteLine, char[] value, int index, int count)
        {
            _writeBufferType = EWriteBufferType.CharArrayWithIndex;
            _value0 = value;
            _index = index;
            _count = count;
            _isWriteLine = isWriteLine;
        }

        internal (char[], int, int) GetValueCharArrayWithIndex() => ((char[])_value0, _index, _count);

        internal WriteBufferContainer(bool isWriteLine, decimal value)
        {
            _writeBufferType = EWriteBufferType.Decimal;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal decimal GetValueDecimal() => (decimal)_value0;

        internal WriteBufferContainer(bool isWriteLine, double value)
        {
            _writeBufferType = EWriteBufferType.Double;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal double GetValueDouble() => (double)_value0;

        internal WriteBufferContainer(bool isWriteLine, int value)
        {
            _writeBufferType = EWriteBufferType.Integer;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal int GetValueInteger() => (int)_value0;

        internal WriteBufferContainer(bool isWriteLine, long value)
        {
            _writeBufferType = EWriteBufferType.Long;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal long GetValueLong() => (long)_value0;

        internal WriteBufferContainer(bool isWriteLine, object? value)
        {
            _writeBufferType = EWriteBufferType.NullableObject;
            _nullableValue0 = value;
            _value0 = _placeHolder;
            _isWriteLine = isWriteLine;
        }

        internal object? GetValueNullableObject() => _nullableValue0;

        internal WriteBufferContainer(bool isWriteLine, float value)
        {
            _writeBufferType = EWriteBufferType.Float;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal float GetValueFloat() => (float)_value0;

        internal WriteBufferContainer(bool isWriteLine, string? value)
        {
            _writeBufferType = EWriteBufferType.NullableString;
            _nullableValue0 = value;
            _value0 = _placeHolder;
            _isWriteLine = isWriteLine;
        }

        internal string? GetValueNullableString() => (string?)_nullableValue0;

        internal WriteBufferContainer(bool isWriteLine, string format, object? arg0)
        {
            _writeBufferType = EWriteBufferType.FormatStringOneNullableObject;
            _value0 = format;
            _nullableValue0 = arg0;
            _isWriteLine = isWriteLine;
        }

        internal (string, object?) GetValueFormatStringOneNullableObject() => ((string)_value0, _nullableValue0);

        internal WriteBufferContainer(bool isWriteLine, string format, object? arg0, object? arg1)
        {
            _writeBufferType = EWriteBufferType.FormatStringTwoNullableObjects;
            _value0 = format;
            _nullableValue0 = arg0;
            _nullableValue1 = arg1;
            _isWriteLine = isWriteLine;
        }

        internal (string, object?, object?) GetValueFormatStringTwoNullableObjects() => ((string)_value0, _nullableValue0, _nullableValue1);

        internal WriteBufferContainer(bool isWriteLine, string format, object? arg0, object? arg1, object? arg2)
        {
            _writeBufferType = EWriteBufferType.FormatStringThreeNullableObjects;
            _value0 = format;
            _nullableValue0 = arg0;
            _nullableValue1 = arg1;
            _nullableValue2 = arg2;
            _isWriteLine = isWriteLine;
        }

        internal (string, object?, object?, object?) GetValueFormatStringThreeNullableObjects() => ((string)_value0, _nullableValue0, _nullableValue1, _nullableValue2);

        internal WriteBufferContainer(bool isWriteLine, string format, params object?[]? arg0)
        {
            _writeBufferType = EWriteBufferType.FormatStringNullableObjectNullableArray;
            _value0 = format;
            _nullableObjectNullableArray = arg0;
            _isWriteLine = isWriteLine;
        }

        internal (string, object?[]?) GetValueFormatStringNullableObjectNullableArray() => ((string)_value0, _nullableObjectNullableArray);

        internal WriteBufferContainer(bool isWriteLine, uint value)
        {
            _writeBufferType = EWriteBufferType.UInt;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal uint GetValueUInt() => (uint)_value0;

        internal WriteBufferContainer(bool isWriteLine, ulong value)
        {
            _writeBufferType = EWriteBufferType.Long;
            _value0 = value;
            _isWriteLine = isWriteLine;
        }

        internal ulong GetValueULong() => (ulong)_value0;
    }
}
