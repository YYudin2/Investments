using System;

namespace Investments
{
    class Program
    {
        static void Main(string[] args)
        {
            Investment loan = new Investment();
            loan.SetParameteres();
            loan.MakeCalculations();
        }
    }
}
