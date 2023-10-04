using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAula5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Disarmando Bomba

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "Bomb disarmed" : "Boom!!");
            });
            t.Start();

            Console.ReadKey();
            cts.Cancel();
            

            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}