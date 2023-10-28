using System;
using System.Threading.Tasks;

namespace DemoAula7
{
    class Program
    {
        static void Main(string[] args)
        {
            // var t = Task.Factory.StartNew(() => { throw new InvalidOperationException("Can't do this") { Source = "t" }; });
            //
            // var t2 = Task.Factory.StartNew(() => { throw new AccessViolationException("Can't do this") { Source = "t2" }; });
            //
            //
            // try
            // {
            //     Task.WaitAll(t, t2);
            // }
            // catch (AggregateException ae)
            // {
            //     foreach (var e in ae.InnerExceptions)
            //     {
            //         Console.WriteLine($"Exception {e.GetType()} from {e.Source}");
            //     }
            // }
            try
            {
                Test();

            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"elsewhere exception: {e.GetType()}");
                }
            }
            Console.WriteLine("Hello World!");
        }

        private static void Test()
        {
            var t = Task.Factory.StartNew(() => { throw new InvalidOperationException("Can't do this") { Source = "t" }; });

            var t2 = Task.Factory.StartNew(() => { throw new AccessViolationException("Can't do this") { Source = "t2" }; });


            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;
                    }

                    return false;
                });
            }
        }
    }
}