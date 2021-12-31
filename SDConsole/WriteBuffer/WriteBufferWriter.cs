using SDConsole.Enums;

using System.Collections.Concurrent;

namespace SDConsole.WriteBuffer
{
    internal static class WriteBufferWriter
    {
        private static readonly ConcurrentQueue<WriteBufferContainer> writeBuffer = new();
        private static readonly Thread writeBufferProcessor = new(ProcessWriteBuffer);

        internal static void Enqueue(WriteBufferContainer writeBufferContainer)
        {
            writeBuffer.Enqueue(writeBufferContainer);
            if (!writeBufferProcessor.ThreadState.Equals(ThreadState.Running))
                writeBufferProcessor.Start();
        }

        private static void ProcessWriteBuffer()
        {
            while (!writeBuffer.IsEmpty)
                if (writeBuffer.TryDequeue(out var writeBufferContainer))
                {
                    SDConsole.PushCursorState();
                    CursorStateHelper.SetCursorState(writeBufferContainer.CursorState);
                    switch (writeBufferContainer.WriteBufferType)
                    {
                        case EWriteBufferType.Bool:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueBool());
                            else
                                Console.Write(writeBufferContainer.GetValueBool());
                            break;
                        case EWriteBufferType.Char:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueChar());
                            else
                                Console.Write(writeBufferContainer.GetValueChar());
                            break;
                        case EWriteBufferType.NullableCharArray:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueNullableCharArray());
                            else
                                Console.Write(writeBufferContainer.GetValueNullableCharArray());
                            break;
                        case EWriteBufferType.CharArrayWithIndex:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueCharArrayWithIndex());
                            else
                                Console.Write(writeBufferContainer.GetValueCharArrayWithIndex());
                            break;
                        case EWriteBufferType.Decimal:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueDecimal());
                            else
                                Console.Write(writeBufferContainer.GetValueDecimal());
                            break;
                        case EWriteBufferType.Double:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueDouble());
                            else
                                Console.Write(writeBufferContainer.GetValueDouble());
                            break;
                        case EWriteBufferType.Integer:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueInteger());
                            else
                                Console.Write(writeBufferContainer.GetValueInteger());
                            break;
                        case EWriteBufferType.Long:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueLong());
                            else
                                Console.Write(writeBufferContainer.GetValueLong());
                            break;
                        case EWriteBufferType.NullableObject:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueNullableObject());
                            else
                                Console.Write(writeBufferContainer.GetValueNullableObject());
                            break;
                        case EWriteBufferType.Float:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer?.GetValueFloat());
                            else
                                Console.Write(writeBufferContainer?.GetValueFloat());
                            break;
                        case EWriteBufferType.NullableString:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueNullableString());
                            else
                                Console.Write(writeBufferContainer.GetValueNullableString());
                            break;
                        case EWriteBufferType.FormatStringOneNullableObject:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueFormatStringOneNullableObject());
                            else
                                Console.Write(writeBufferContainer.GetValueFormatStringOneNullableObject());
                            break;
                        case EWriteBufferType.FormatStringTwoNullableObjects:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueFormatStringTwoNullableObjects());
                            else
                                Console.Write(writeBufferContainer.GetValueFormatStringTwoNullableObjects());
                            break;
                        case EWriteBufferType.FormatStringThreeNullableObjects:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueFormatStringThreeNullableObjects());
                            else
                                Console.Write(writeBufferContainer.GetValueFormatStringThreeNullableObjects());
                            break;
                        case EWriteBufferType.FormatStringNullableObjectNullableArray:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueFormatStringNullableObjectNullableArray());
                            else
                                Console.Write(writeBufferContainer.GetValueFormatStringNullableObjectNullableArray());
                            break;
                        case EWriteBufferType.UInt:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueUInt());
                            else
                                Console.Write(writeBufferContainer.GetValueUInt());
                            break;
                        case EWriteBufferType.ULong:
                            if (writeBufferContainer.IsWriteLine)
                                Console.WriteLine(writeBufferContainer.GetValueULong());
                            else
                                Console.Write(writeBufferContainer.GetValueULong());
                            break;
                        default: // unknown
                            // TODO: throw an exception
                            break;
                    }
                    SDConsole.PopCursorState();
                }
            Thread.Yield();
        }
    }
}
