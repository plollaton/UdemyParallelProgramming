using System;
using System.Threading.Tasks;

namespace TasksDemo
{
    class Program
    {
        private static void Write(char c)
        {
            int i = 1000;
            while (i -- > 0)
            {
                Console.Write(c);
            }
        }
        
        private static void Write(object o)
        {
            int i = 1000;
            while (i -- > 0)
            {
                Console.Write(o);
            }
        }

        private static int TextLength(object o)
        {
            
            Console.WriteLine($"Task with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }
        
        static void Main(string[] args)
        {
            // Task.Factory.StartNew(() => Write('.'));
            //
            // var t = new Task(Write, "123");
            // t.Start();
            //
            // Write('-');
            //
            // Console.WriteLine("Hello World!");

            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew<int>(TextLength, text2);
            
            Console.WriteLine($"Length of '{text1}' is {task1.Result}.");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}.");

        }
    }
}