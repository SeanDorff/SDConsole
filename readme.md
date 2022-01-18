Include the namespace SDConsNS.
Acquire a lock on the cursor with lock(SDConsole.GetCursorStateLock()).
Modify the console state as desired, e.g. Console.SetCursorPosition(42, 42).
Write to the console with SDConsole.Write("my text").