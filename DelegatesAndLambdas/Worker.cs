using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; ++i)
            {
                // Raise event for each hour worked.
            }
            // Raise event for work completed.
        }
    }
}
