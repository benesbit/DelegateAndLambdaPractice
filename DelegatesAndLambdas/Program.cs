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

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(firstValue, secondValue, addDel);
            data.Process(firstValue, secondValue, multiplyDel);

            Action<int, int> myModAction = (x, y) => Console.WriteLine($"{x} mod {y} = {x % y}");
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine($"{x} * {y} = {multiplyDel(x, y)}");

            data.ProcessAction(firstValue, secondValue, myModAction);
            data.ProcessAction(firstValue, secondValue, myMultiplyAction);
        }

        private static void BasicDelegateExamples(int hoursWorked)
        {
            var worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(hoursWorked, WorkType.GenerateReports);
        }

        private void BasicDelegateAnonymousFunctionExamples(int first, int second)
        {
            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine($"{e.Hours} Hour" + ((e.Hours > 1) ? "s" : "") + $" worked\t Work Type: {e.WorkType}");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done!");
            worker.DoWork(8, WorkType.GenerateReports);
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
