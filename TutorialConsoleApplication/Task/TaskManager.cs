using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace TutorialConsoleApplication.Task
{
    sealed class TaskManager
    {

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
                Thread.Sleep(3000);
            }
            
        }

        private void newProcessFound(Process process) {
            tasks.Add(new MyTask(process.Id, process.ProcessName));
        }


    }
}
