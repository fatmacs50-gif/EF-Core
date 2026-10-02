// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.Configuration;
namespace EF_CoreInternal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new Data.AppDbcontext())
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine($"Id: {wallet.Id}, Holder: {wallet.Holder}, Balance: {wallet.Balance}");
                }
            }
            Console.ReadKey();

        }
    }
}
