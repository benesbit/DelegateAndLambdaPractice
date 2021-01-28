using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    //public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; ++i)
            {
                // Slow down on purpose - NOT A NORMAL STEP, FOR DEMO ONLY
                System.Threading.Thread.Sleep(1000);
                // Raise event for each hour worked.
                OnWorkPerformed(i + 1, workType);
            }
            // Raise event for work completed.
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
