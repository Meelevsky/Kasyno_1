using System;
using NUnit.Framework;

namespace Kasyno_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dr = new DataRepository(new WypelnianieStalymi());

            var dr2 = new DataRepository(new WypelnianieStalymiJSON());
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
