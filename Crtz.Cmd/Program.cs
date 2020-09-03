using Crtz.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crtz.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            Register register = store.GetRegister();
            Worker(register);
        }

        private static void Worker(Register register)
        {   
            Console.WriteLine("---- SALE SYSTEM ----");

            register.BeginNewSale();

            Console.WriteLine();
            Console.WriteLine("Type: N to add a Product, P to Payment F to Finish a Sale and Q to Quit");
            Console.WriteLine();

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                try
                {
                    ConsoleKeyInfo typedKey = Console.ReadKey();

                    switch (typedKey.Key)
                    {
                        case ConsoleKey.N:
                            Console.WriteLine();
                            int productId = new Random().Next(1, 5);
                            register.SetItem(productId, 5);
                            continue;

                        case ConsoleKey.P:
                            Console.WriteLine();
                            register.DoPayment(500);
                            continue;

                        case ConsoleKey.F:
                            Console.WriteLine();
                            register.FinishSale();
                            continue;

                        case ConsoleKey.Q:
                            Console.WriteLine();
                            cancellationToken.Cancel();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error");
                }
            }
        }
    }
}
