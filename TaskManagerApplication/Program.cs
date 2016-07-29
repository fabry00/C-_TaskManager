using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialConsoleApplication.Task;
using TutorialConsoleApplication.Displayer;

namespace TutorialConsoleApplication
{
    class Program
    {
        delegate void myDlg(string s);

        delegate string mydlg2();

        delegate Animal muDlg3();

        static void Main(string[] args)
        {
            MyDisplayer displayer = new MyDisplayer();
            TaskManager manager = new TaskManager();
            manager.NewTask += displayer.NewTask;
            manager.ProcessRemoved += displayer.ProcessRemoved;

            Console.WriteLine("Press ESC to exit");
            do
            {
                Console.WriteLine("Running app");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

           /* myDlg del = new myDlg(TestFunction);
            del("Hellow world"); //Puntatore a TestFunction

            //Oppure Compiler automatically injet --> Method group conversion
            myDlg del2 = TestFunction;

            // We can add more pointer --> TestFunction will be called 2 times
            // del2 is called InvocationList
            del2 += TestFunction;


            mydlg2 testDlg = TestFunction2;
            testDlg += TestFunction3;

            string result = testDlg(); // --> quale risultato torna?? quello di Test2 o Test3??
            // --> torna solo quello di 3, l'utlimo

        */

        }

        static Dog MyDogFunction() {
            return null;
        }

        static string TestFunction2() {
            return "TESTO RETURNED";
        }

        static string TestFunction3()
        {
            return "Test 2";
        }

        static void TestFunction(string text) {
            Console.WriteLine(text);
        }
    }

    class Animal
    {

    }

    class Dog : Animal {
    }
}
