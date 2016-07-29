using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialConsoleApplication.Task
{
    class NewTaskEventArgs : EventArgs
    {
        // If you have a property with an internal set accessor
        // (and public get accessor) it means that code within the assembly 
        // can read (get) and write (set) the property, but other code can only read it.
        public IMyTask task { get; internal set; }

        public NewTaskEventArgs(IMyTask task) {
            this.task = task;
        }      
    }
}
