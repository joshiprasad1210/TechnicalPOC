using System;
using System.Threading;

namespace DelegateCallback
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SomeClass s = new SomeClass();
            s.sender = Print;
            s.sender += ShowSuccess;
            s.HugePorcess();
        }
        public static void Print(int percentageOfCompletion)
        {
            Console.WriteLine("Completed {0}  %", percentageOfCompletion);
        }
        public static void ShowSuccess(int percentageOfCompletion)
        {
            if (percentageOfCompletion % 10 == 0)
            {
                Console.WriteLine("Good Progress");
            }
        }
    }

    class SomeClass
    {
        public delegate void Sender(int percentageOfCompletion);
        public Sender sender = null;

        public void HugePorcess()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                sender(i);
            }
        }
    }
}
