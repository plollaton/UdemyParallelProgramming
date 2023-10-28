using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAula6
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds...");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I'm done.");
                
            }, token);
            
            t.Start();

            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000));

            // Task.WaitAll(t, t2);
            Task.WaitAll(new[] {t, t2}, 4000, token);
            
            Console.WriteLine($"T status {t.Status}");
            Console.WriteLine($"T2 status {t2.Status}");
            
            
            
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            
        }
    }
}