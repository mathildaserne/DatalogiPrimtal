using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Uppgift1Primtal
{
    class Program
    {
        static void Main(string[] args)
        {
            Color colors = new Color();
            colors.color();
            Prime prime = new Prime();
            prime.Start();
            prime.CheckPrime();
        }
    }
}
