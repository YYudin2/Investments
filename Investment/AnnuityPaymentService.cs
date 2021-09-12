using System;
using System.Collections.Generic;
using System.Linq;

namespace Investments
{
    internal class AnnuityPaymentService
    {
        public void CalculatePayments(Loan loan)
        {
            var (principal, maturityDate, rate, issueDate) = loan;
            var monthlyRate = rate / 12.0;
            var months = (maturityDate.Year - issueDate.Year) * 12 + maturityDate.Month - issueDate.Month;
            var paymentValue = principal * monthlyRate /
                               (1 - Math.Pow(1 + monthlyRate, -months));

            var remainedPrincipal = principal;
            var payments = new List<Payment>(months);
            for (var i = 0; i < months; i++)
            {
                var payment = new Payment
                {
                    InterestPayment = remainedPrincipal * monthlyRate,
                    PaymentDate = issueDate.AddMonths(i)
                };
                payment.PrincipalPayment = paymentValue - payment.InterestPayment;
                payments.Add(payment);

                remainedPrincipal -= payment.PrincipalPayment;
            }

            loan.Payments = payments;
        }

        public CalculationResult Calculate(CalculationRequest request, Loan loan)
        {
            return new CalculationResult
            {
                Payments = loan.Payments.Where(payment => payment.PaymentDate >= request.CalculationDate)
                    .ToList(),
                Loan = loan,
                Timestamp = DateTime.Now,
            };
        }
    }
}
