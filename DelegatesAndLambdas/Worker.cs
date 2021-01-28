using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {
        public event WorkPerformedHandler WrokPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {

        }
    }
}
