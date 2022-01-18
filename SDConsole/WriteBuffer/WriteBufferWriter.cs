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

                    dynamic? value;

                    switch (writeBufferContainer.WriteBufferType)
                    {
                        case EWriteBufferType.Bool:
                            value = writeBufferContainer.GetValueBool();
                            break;
                        case EWriteBufferType.Char:
                            value = writeBufferContainer.GetValueChar();
                            break;
                        case EWriteBufferType.NullableCharArray:
                            value = writeBufferContainer.GetValueNullableCharArray();
                            break;
                        case EWriteBufferType.CharArrayWithIndex:
                            value = writeBufferContainer.GetValueCharArrayWithIndex();
                            break;
                        case EWriteBufferType.Decimal:
                            value = writeBufferContainer.GetValueDecimal();
                            break;
                        case EWriteBufferType.Double:
                            value = writeBufferContainer.GetValueDouble();
                            break;
                        case EWriteBufferType.Integer:
                            value = writeBufferContainer.GetValueInteger();
                            break;
                        case EWriteBufferType.Long:
                            value = writeBufferContainer.GetValueLong();
                            break;
                        case EWriteBufferType.NullableObject:
                            value = writeBufferContainer.GetValueNullableObject();
                            break;
                        case EWriteBufferType.Float:
                            value = writeBufferContainer.GetValueFloat();
                            break;
                        case EWriteBufferType.NullableString:
                            value = writeBufferContainer.GetValueNullableString();
                            break;
                        case EWriteBufferType.FormatStringOneNullableObject:
                            value = writeBufferContainer.GetValueFormatStringOneNullableObject();
                            break;
                        case EWriteBufferType.FormatStringTwoNullableObjects:
                            value = writeBufferContainer.GetValueFormatStringTwoNullableObjects();
                            break;
                        case EWriteBufferType.FormatStringThreeNullableObjects:
                            value = writeBufferContainer.GetValueFormatStringThreeNullableObjects();
                            break;
                        case EWriteBufferType.FormatStringNullableObjectNullableArray:
                            value = writeBufferContainer.GetValueFormatStringNullableObjectNullableArray();
                            break;
                        case EWriteBufferType.UInt:
                            value = writeBufferContainer.GetValueUInt();
                            break;
                        case EWriteBufferType.ULong:
                            value = writeBufferContainer.GetValueULong();
                            break;
                        default: // unknown
                            throw new ArgumentException("Unknown WriteBufferContainer value type");
                    }

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
