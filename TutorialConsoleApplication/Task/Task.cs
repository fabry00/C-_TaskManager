using System;
using TutorialConsoleApplication.Task;

namespace TutorialConsoleApplication
{
    class MyTask : IMyTask
    {
        private int pid { get; /*set;*/ }
        private string name { get; /*set;*/ }

        public MyTask(int pid, string name){
            this.pid = pid;
            this.name = name;
        }

        public int getPid()
        {
            return pid;
        }

        public string getName()
        {
            return name;
        }

        public override string ToString()
        {
            return pid + " - " + name;
        }


        public override bool Equals(object obj)
        {
            // if parameter is null return false
            if (obj == null) {
                return false;
            }

            MyTask other = obj as MyTask;
            // If parameter cannot be cast to Task return false
            if ((System.Object)other == null) {
                return false;
            }

            return Equals(other);
        }

        public bool Equals(MyTask other) {

            // If parameter is null return false;
            if ((object)other == null) {
                return false;
            }
            
            return pid == other.pid && name == other.name;
        }

        public override int GetHashCode()
        {
            return pid ^ name.GetHashCode();
        }

        
    }
}
