using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAula4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region Simple Case
            // var cts = new CancellationTokenSource();
            // var token = cts.Token;
            // token.Register(() =>
            // {
            //     Console.WriteLine("Cancelation has been requested...");
            // });
            //
            // var t = new Task(() =>
            // {
            //     int i = 0;
            //     while (true)
            //     {
            //         // if (token.IsCancellationRequested)
            //         //     //break;
            //         //     throw new OperationCanceledException();
            //         token.ThrowIfCancellationRequested();
            //         
            //         Console.WriteLine($"{i++}\t");
            //     }
            // }, token);
            //
            // t.Start();
            //
            // Task.Factory.StartNew(() =>
            // {
            //     token.WaitHandle.WaitOne();
            //     Console.WriteLine("Wait handle release, cancelation was requested.");
            // });
            //
            // Console.ReadKey();
            // cts.Cancel();
            #endregion

            #region Complex Case

            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
                planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
            }, paranoid.Token);

            Console.ReadKey();
            emergency.Cancel();
            #endregion            
            Console.WriteLine("Hello World!");
        }
    }
}