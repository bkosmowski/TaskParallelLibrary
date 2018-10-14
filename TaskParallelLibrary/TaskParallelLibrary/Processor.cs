using System;
using System.Threading;

namespace TaskParallelLibrary
{
    public class Processor
    {
        public static void ShowThreadNumberInformation()
        {
            var processorCount = Environment.ProcessorCount;
            ThreadPool.GetMinThreads(out var minimumWorkerThreads, out var completionPortThreads);
            ThreadPool.GetAvailableThreads(out var availableWorkerThreads, out var availableCompletionPortThreads);
            ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);

            Console.WriteLine($"Number of processors: {processorCount}");
            Console.WriteLine($"Minimum of worker threads: {minimumWorkerThreads}");
            Console.WriteLine($"Minimum of completion port threads: {completionPortThreads}");
            Console.WriteLine($"Available of worker threads: {availableWorkerThreads}");
            Console.WriteLine($"Minimum of completion port threads: {availableCompletionPortThreads}");
            Console.WriteLine($"Maximum of worker threads: {maxWorkerThreads}");
            Console.WriteLine($"Maximum of completion port threads: {maxCompletionPortThreads}");
        }
    }
}