using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Client
{
    internal class TryCatchProxy : ITryCatchProxy
    {
        public async Task Try(Func<Task> action, Action<Exception>? OnExceptionOccured = null, [CallerFilePath] string? path = null, [CallerMemberName] string? caller = null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Start [{path} {caller}]");
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH.mm:ss}] [Error] [{path} {caller}] - {ex.Message}");
                OnExceptionOccured?.Invoke(ex);
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"End [{path} {caller}]");
                if (stopwatch.ElapsedMilliseconds > 500)
                {
                    Console.WriteLine($"Duration over 500ms [{stopwatch.ElapsedMilliseconds}ms]");
                }
            }
        }
    }

    internal interface ITryCatchProxy
    {
        public Task Try(Func<Task> action, Action<Exception>? OnExceptionOccured = null, [CallerFilePath] string? path = null, [CallerMemberName] string? caller = null);
    }
}
