using System;

namespace DelegatesAndLambdas
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            int firstValue = 2;
            int secondValue = 3;
            int hoursWorked = 8;

            BasicDelegateExamples(hoursWorked);

            BasicDelegateAnonymousFunctionExamples(hoursWorked);

            BasicActionTExamples(firstValue, secondValue);
        }

        private static void BasicActionTExamples(int first, int second)
        {
            Console.WriteLine($"---------- Begin Action<T> Delegate Example ----------");

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(first, second, addDel);
            data.Process(first, second, multiplyDel);

            // Slow down on purpose - NOT A NORMAL STEP, FOR DEMO ONLY
            System.Threading.Thread.Sleep(1000);

            Action<int, int> myModAction = (x, y) => Console.WriteLine($"{x} mod {y} = {x % y}");

            // Slow down on purpose - NOT A NORMAL STEP, FOR DEMO ONLY
            System.Threading.Thread.Sleep(1000);

            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine($"{x} * {y} = {multiplyDel(x, y)}");

            data.ProcessAction(first, second, myModAction);
            data.ProcessAction(first, second, myMultiplyAction);

            Console.WriteLine($"---------- End Action<T> Delegate Example ----------\n\n");
        }

        private static void BasicDelegateAnonymousFunctionExamples(int hoursWorked)
        {
            Console.WriteLine($"---------- Begin Anonymous Function Delegate Example ----------");

            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine($"{e.Hours} Hour" + ((e.Hours > 1) ? "s" : "") + $" worked\t Work Type: {e.WorkType}");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done!");
            worker.DoWork(hoursWorked, WorkType.GenerateReports);

            Console.WriteLine($"---------- End Anonymous Function Delegate Example ----------\n\n");
        }

        private static void BasicDelegateExamples(int hoursWorked)
        {
            Console.WriteLine($"---------- Begin Basic Delegate Example ----------");

            var worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(hoursWorked, WorkType.GenerateReports);

            Console.WriteLine($"---------- End Basic Delegate Example ----------\n\n");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Hours worked: {e.Hours}\t Work Type: {e.WorkType}");
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done!");
        }
    }
}
