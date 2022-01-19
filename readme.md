# About **SDConsole**
**SDConsole** is a wrapper around `Console` and aimed at concurrent threads which write text to the console.  
Threads can use the usual `Write()` and `WriteLine()` methods to write to **SDConsole**.  
**SDConsole** will buffer the current cursor status along with the desired output and process the buffered commands later. This way multiple threads can safely output the desired text without handling concurrency issues.
# Include in your project
The easiest way to include **SDConsole** in your project is by including the [SDConsole Nuget Package](https://www.nuget.org/packages/SDConsole/).  
You can also download the source code from [SDConsole on GitHub](https://github.com/SeanDorff/SDConsole/).
# Usage
## Text output
Below is an example for using **SDConsole** in C#.  
```
using SDConNS; // (1)

namespace Example
{
    public class ExampleClass
    {
        public void ExampleMethod()
        {
            lock (SDConsole.GetCursorStateLock()) // (2)
            {
                Console.SetCursorPosition(42, 42); // (3)
                SDConsole.Write("Example text"); // (4)
            }
        }
    }
}
```
### Explanation
1. `using SDConNS` includes the **SDConsole** namespace.
2. `lock (SDConsole.GetCursorStateLock())` acquires a lock from **SDConsole**. This ensures that no other thread will be able to modify the cursor status until the `Write()` method has been executed.
3. `Console.SetCursorPosition(42, 42)` is an example for how you can modify the current cursor status. You could also modify the color or if the cursor itself is visible. **SDConsole** will preserve the set status and apply it accordingly when the actual text output takes place.
4. `SDConsole.Write("Example text")` stores "Example text" in the output buffer of **SDConsole** along with the current cursor status.
## Control thread sleep time
The default thread sleep time of the buffer processor is `30` milliseconds.  
You can alter and reset that value using the methods below.
```
SDConsole.SetThreadSleepTime(42);
SDConsole.ResetThreadSleepTime();
```