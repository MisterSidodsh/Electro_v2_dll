using System;
using Electro_v2_dll;

namespace Electro_v2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to use console app");
            Console.WriteLine("Press 2 to use GUI app");
            Console.WriteLine("Awaiting input...");
            char decision = Convert.ToChar(Console.ReadLine());
            if (decision == '1')
            {
                var socket = ApplianceFactory.CreatePowerSocket();

                var printer = new Printer();
                printer.Print(socket);

                Console.ReadKey();
            }
            else
            {
                Main main = new Main();
                main.ShowDialog();
            }
        }
    }
}