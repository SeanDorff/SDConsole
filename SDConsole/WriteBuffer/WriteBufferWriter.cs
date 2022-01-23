using SDConNS.Enums;

using System.Collections.Concurrent;

namespace SDConNS.WriteBuffer
{
    internal static class WriteBufferWriter
    {
        /// <summary>
        /// Default thread sleep time is 30 milliseconds.
        /// </summary>
        private const int DEFAULT_SLEEP_TIME = 30;

        private static readonly ConcurrentQueue<WriteBufferContainer> writeBuffer = new();
        private static readonly Thread writeBufferProcessor = new(ProcessWriteBuffer);
        private static bool useDefaultSleepTime = true;
        private static int customSleepTime = DEFAULT_SLEEP_TIME;

        static WriteBufferWriter()
        {
            writeBufferProcessor.Start();
        }

        internal static void Enqueue(WriteBufferContainer writeBufferContainer) => writeBuffer.Enqueue(writeBufferContainer);

        private static void ProcessWriteBuffer()
        {
            while (!writeBuffer.IsEmpty)
                if (writeBuffer.TryDequeue(out var writeBufferContainer))
                {
                    SDConsole.PushCursorState();
                    CursorStateHelper.SetCursorState(writeBufferContainer.CursorState);
                    dynamic? value = writeBufferContainer.WriteBufferType switch
                    {
                        EWriteBufferType.Bool => writeBufferContainer.GetValueBool(),
                        EWriteBufferType.Char => writeBufferContainer.GetValueChar(),
                        EWriteBufferType.NullableCharArray => writeBufferContainer.GetValueNullableCharArray(),
                        EWriteBufferType.CharArrayWithIndex => writeBufferContainer.GetValueCharArrayWithIndex(),
                        EWriteBufferType.Decimal => writeBufferContainer.GetValueDecimal(),
                        EWriteBufferType.Double => writeBufferContainer.GetValueDouble(),
                        EWriteBufferType.Integer => writeBufferContainer.GetValueInteger(),
                        EWriteBufferType.Long => writeBufferContainer.GetValueLong(),
                        EWriteBufferType.NullableObject => writeBufferContainer.GetValueNullableObject(),
                        EWriteBufferType.Float => writeBufferContainer.GetValueFloat(),
                        EWriteBufferType.NullableString => writeBufferContainer.GetValueNullableString(),
                        EWriteBufferType.FormatStringOneNullableObject => writeBufferContainer.GetValueFormatStringOneNullableObject(),
                        EWriteBufferType.FormatStringTwoNullableObjects => writeBufferContainer.GetValueFormatStringTwoNullableObjects(),
                        EWriteBufferType.FormatStringThreeNullableObjects => writeBufferContainer.GetValueFormatStringThreeNullableObjects(),
                        EWriteBufferType.FormatStringNullableObjectNullableArray => writeBufferContainer.GetValueFormatStringNullableObjectNullableArray(),
                        EWriteBufferType.UInt => writeBufferContainer.GetValueUInt(),
                        EWriteBufferType.ULong => writeBufferContainer.GetValueULong(),
                        _ => throw new ArgumentException("Unknown WriteBufferContainer value type"),
                    };
                    if (writeBufferContainer.IsWriteLine)
                        Console.WriteLine(value);
                    else
                        Console.Write(value);

                    SDConsole.PopCursorState();
                }
            if (useDefaultSleepTime)
                Thread.Sleep(DEFAULT_SLEEP_TIME);
            else
                Thread.Sleep(customSleepTime);
        }

        /// <summary>
        /// Set a custom thread sleep time.
        /// </summary>
        /// <param name="sleep">Thread sleep time in milliseconds</param>
        internal static void SetThreadSleepTime(int sleep)
        {
            customSleepTime = sleep;
            useDefaultSleepTime = customSleepTime != DEFAULT_SLEEP_TIME;
        }

        /// <summary>
        /// Reset the thread sleep time to the default.
        /// </summary>
        internal static void ResetThreadSleepTime()
        {
            customSleepTime = DEFAULT_SLEEP_TIME;
            useDefaultSleepTime = true;
        }
    }
}
