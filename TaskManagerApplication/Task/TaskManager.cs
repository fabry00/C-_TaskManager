using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace TutorialConsoleApplication.Task
{
    sealed class TaskManager
    {
        public event EventHandler<NewTaskEventArgs> NewTask;
        public event EventHandler<NewTaskEventArgs> ProcessRemoved;

        private List<IMyTask> tasks { get; }
        private Thread myThread;

        public TaskManager()
        {
            tasks = new List<IMyTask>();
            myThread = new Thread(new ThreadStart(Run));
            myThread.Start();

        }

        public void Run() {
            Console.WriteLine("Run");
            while (true)
            {
                Process[] processlist = Process.GetProcesses();
                foreach(Process process in processlist)
                {
                    if (!tasks.Exists(p => p.getPid() == process.Id)) {
                        newProcessFound(process);
                    }
                }

                List<IMyTask> toRemove = new List<IMyTask>();
                foreach (var task in tasks)
                {
                    Boolean found = false;
                    foreach (Process p in processlist) {
                        if (p.Id == task.getPid()) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        toRemove.Add(task);
                    }
                }
                removeTasks(toRemove);
                     
                Thread.Sleep(3000);
            }
            
        }

        private void removeTasks(List<IMyTask> toRemove)
        {
            tasks.RemoveAll(x => toRemove.Contains(x));
            toRemove.ForEach(x => ProcessRemoved(this, new NewTaskEventArgs(x)));
        }

        private void newProcessFound(Process process) {
            IMyTask task = new MyTask(process.Id, process.ProcessName);
            tasks.Add(task);
            NewTaskEventArgs args = new NewTaskEventArgs(task);
            NewTask(this, args);
        }


    }
}
