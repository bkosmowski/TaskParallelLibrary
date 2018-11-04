using System;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class StartingTasks
    {
        public static void CreateAndStartTask()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello Tasks!");
            });

            var task = new Task(() => Write("?"));

            task.Start();

            Write('.');
        }

        public static void CreateTaskWithArg(object arg)
        {
            Task.Factory.StartNew(Write, arg);

            var task = new Task(Write, arg);

            task.Start();
        }

        public static void CalculateTextLengthInTask(object o)
        {
            Console.WriteLine($"Task with id {Task.CurrentId} is processing object {o}...");

            var task = new Task<int>(TextLength, o);

            task.Start();

            Console.WriteLine($"Length of text is equals to {task.Result}");
        }

        private static int TextLength(object o)
        {
            return o.ToString().Length;
        }

        private static void Write(char c)
        {
            var i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        private static void Write(object o)
        {
            var i = 1000;
            while (i-- > 0)
            {
                Console.Write(o.ToString());
            }
        }
    }
}
