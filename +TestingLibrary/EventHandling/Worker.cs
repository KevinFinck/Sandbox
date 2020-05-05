using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.EventHandling
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public int HoursWorked { get; set; }
    }
    // public delegate int WorkPerformedHandler(object sender, WorkerEventArgs eventArgs);
    // OR: use as type of ==> EventHandler<WorkPerformedEventArgs>


    public class Worker
    {

        //public event WorkPerformedHandler WorkPerformedEvent;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformedEvent;
        public event EventHandler WorkCompletedEvent;

        public void DoWork(int hoursToWork)
        {
            //if (WorkPerformedEvent != null)
            //{
            //    WorkPerformedEvent(hours);
            //}
            // Or:  WorkPerformedEvent?.Invoke(hours);

            // Cast event back to handler if you wana.
            //var handler = WorkPerformedEvent as WorkPerformedHandler;
            //handler?.Invoke(2);

            for (int i = 0; i < hoursToWork; i++)
            {
                OnWorkPerformed(i+1);
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours)
        {
            WorkPerformedEvent?.Invoke(this, new WorkPerformedEventArgs { HoursWorked = hours});
        }
        protected virtual void OnWorkCompleted()
        {
            WorkCompletedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
