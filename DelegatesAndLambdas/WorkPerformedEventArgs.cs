using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    public class WorkPerformedEventArgs : EventArgs
    {

        public WorkPerformedEventArgs()
        {

        }

        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
