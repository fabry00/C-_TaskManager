using System;
using TutorialConsoleApplication.Task;
namespace TutorialConsoleApplication.Displayer
{
    class MyDisplayer
    {
        internal void NewTask(object sender, NewTaskEventArgs args)
        {
            Console.WriteLine("New Task: " + args.task.getName() );
        }

        internal void ProcessRemoved(object sender, NewTaskEventArgs args)
        {
            Console.WriteLine("Removed Task: " + args.task.getName());
        }
    }
}
