using System;

namespace Investments
{
    internal class UserInteraction
    {
        public CalculationRequest GetCalculationRequest()
        {
            var calculationRequest = new CalculationRequest();
            while (true)
            {
                Console.WriteLine("Please set calculation date or type 'Exit' to exit.");
                var inputData = Console.ReadLine();
                if (inputData == "Exit")
                {
                    return null;
                }
                if (DateTime.TryParse(inputData, out DateTime calculationDate))
                {
                    calculationRequest.CalculationDate = calculationDate;
                    break;
                }

                Console.WriteLine("Incorrect calculation date entered, please try again.");
            }
            return calculationRequest;
        }

        public Loan GetLoan()
        {
            var loan = new Loan();
            while (true)
            {
                Console.WriteLine("Please set amount of investment:");
                var inputData = Console.ReadLine();
                if (double.TryParse(inputData, out double amount) && amount > 0)
                {
                    loan.Principal = amount;
                    break;
                }
                Console.WriteLine("Incorrect amount entered, please try again.");
            }

            while (true)
            {
                Console.WriteLine("Please set agreement date:");
                var inputData = Console.ReadLine();
                if (DateTime.TryParse(inputData, out DateTime issueDate))
                {
                    loan.IssueDate = issueDate;
                    break;
                }

                Console.WriteLine("Incorrect agreement date entered, please try again.");
            }

            while (true)
            {
                Console.WriteLine("Please set number of years investment");
                var inputData = Console.ReadLine();
                if (int.TryParse(inputData, out int years) && years > 0)
                {
                    loan.MaturityDate = loan.IssueDate.AddYears(years);
                    break;
                }

                Console.WriteLine("Incorrect years entered, please try again.");
            }

            while (true)
            {
                Console.WriteLine("Please set number of yearly rate in decimal format: *,* ");
                var inputData = Console.ReadLine();
                if (double.TryParse(inputData, out double rate) && rate > 0)
                {
                    loan.Rate = rate;
                    break;
                }

                Console.WriteLine("Incorrect rate entered, please try again.");
            }
            return loan;
        }

        public void ShowCalculationResult(CalculationResult calculationResult)
        {
            Console.WriteLine($"Calculation completed for {calculationResult.Loan}, calculation time: {calculationResult.Timestamp}.");
            double interestPaymentsSum = 0;
            foreach (var payment in calculationResult.Payments)
            {
                Console.WriteLine(payment);
                interestPaymentsSum += payment.InterestPayment;
            }
            Console.WriteLine($"Total interest sum is {interestPaymentsSum:f2} ");
        }
    }
}
