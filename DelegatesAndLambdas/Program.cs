using System;

namespace DelegatesAndLambdas
{
    
    class Program
    {
        static void Main(string[] args)
        {
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

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
