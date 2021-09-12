using System;
using System.Globalization;

namespace Investments
{
    public class Investment
    {
        private uint Years { get; set; }

        private DateTime AgrDate { get; set; }

        private uint MonthsinAgreement 
        { 
            get
            { return Years * 12; }                
        }

        private double Amount;

        private double Rate { get; set; }

        private double MonthlyInt
        {
            get
            { return Rate / 12; }
        }
        private double InPower
        {
            get
            { return Math.Pow((1 + MonthlyInt), (-MonthsinAgreement)); }
        }

        private double Payment
        {
            get
            {
                return Amount * MonthlyInt / (1 - InPower);
            }
        }

         public void SetParameteres ()
        {
            Console.WriteLine("Please set amount of investment");
            try
            {
                var amount = Console.ReadLine();
                Amount = double.Parse(amount);
                if (Amount <=0)
                {
                    throw new ArgumentException("Amount must be greater then 0");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Please set number of years investment");
            try
            {
                var years = Console.ReadLine();
                Years = uint.Parse(years);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Please set number of yearly rate in decimal format: *,* ");

            try
            {
                var rate = Console.ReadLine();
                Rate = double.Parse(rate);
                if (Rate <= 0)
                {
                    throw new ArgumentException("Rate cannot be less or 0");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Please set agreement date");
            try
            {
                var agrdate = Console.ReadLine();
                AgrDate = DateTime.Parse(agrdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void ShowParameteres()
        {
            Console.WriteLine($"Amount of investment: {Amount:f2}");

            Console.WriteLine($"Months of investment: {MonthsinAgreement}");

            Console.WriteLine($"Monthly rate: {MonthlyInt:p}");

            Console.WriteLine($"Agreement date: {AgrDate: d}");

            Console.WriteLine($"Monthly payment:{Payment:f2}");

        }
        public void MakeCalculations ()

        {
            var remained = Amount;
            DateTime Caldate = new DateTime();
            Console.WriteLine("Please set calculation date");
            try
            {
                var caldate = Console.ReadLine();
                Caldate = DateTime.Parse(caldate);
                if (Caldate < AgrDate)
                { throw new ArgumentException("Date of calculation must be after Agreement Date"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var months = (Caldate.Year - AgrDate.Year) * 12 + Caldate.Month - AgrDate.Month;

            for (int i = 1; i <= months; i++)
            {
                var IntPayment = remained * MonthlyInt;
                var PrPayment = Payment - IntPayment;
                remained -= PrPayment;
            }
            double SumInt = 0;
            DateTime date = Caldate;
            while (date.Day != AgrDate.Day)
            {
                 date=date.AddDays(1);
            }

            for (int i = months + 1; i <= MonthsinAgreement; i++)
            {
                var IntPayment = remained * MonthlyInt;
                var PrPayment = Payment - IntPayment;
                remained -= PrPayment;
                SumInt += IntPayment;

                Console.WriteLine($"For month {i} as of date {date:d} interest payment is {IntPayment:f2}, principal payment is: {PrPayment:f2}, total payment: {Payment:f2}");
                date = date.AddMonths(1);
            }
            Console.WriteLine($"Total interest sum is {SumInt:f2} ");
        }







    }
}