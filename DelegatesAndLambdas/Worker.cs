using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; ++i)
            {
                // Raise event for each hour worked.
                OnWorkPerformed(i + 1, workType);
            }
            // Raise event for work completed.
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, WorkType);
            //}

            var del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours, workType);
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(hours, WorkType);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
