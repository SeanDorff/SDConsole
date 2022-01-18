using SDConNS.Enums;

using System.Collections.Concurrent;

namespace SDConNS.WriteBuffer
{
    internal static class WriteBufferWriter
    {
        private static readonly ConcurrentQueue<WriteBufferContainer> writeBuffer = new();
        private static readonly Thread writeBufferProcessor = new(ProcessWriteBuffer);
        private static bool processorStarted = false;
        private static object lockObject = new();

        internal static void Enqueue(WriteBufferContainer writeBufferContainer)
        {
            writeBuffer.Enqueue(writeBufferContainer);
            if (!processorStarted)
                lock (lockObject)
                {
                    if (!processorStarted)
                        writeBufferProcessor.Start();
                    processorStarted = true;
                }
        }

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
            Thread.Yield();
        }
    }
}
