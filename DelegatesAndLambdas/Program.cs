using System;

namespace DelegatesAndLambdas
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, addDel);
            data.Process(2, 3, multiplyDel);

            Action<int, int> myModAction = (x, y) => Console.WriteLine($"{x} mod {y} = {x % y}");
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine($"{x} * {y} = {multiplyDel(x, y)}");

            data.ProcessAction(2, 3, myModAction);
            data.ProcessAction(2, 3, myMultiplyAction);


            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine($"{e.Hours} Hour" + ((e.Hours > 1) ? "s" : "") + $" worked\t Work Type: {e.WorkType}");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done!");
            worker.DoWork(8, WorkType.GenerateReports);
        }

        //private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine($"Hours worked: {e.Hours}\t Work Type: {e.WorkType}");
        //}

        //private static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done!");
        //}
    }
}
