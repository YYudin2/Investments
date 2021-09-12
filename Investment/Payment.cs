using System;

namespace Investments
{
    internal class Payment
    {
        public double PrincipalPayment { get; set; }
        public double InterestPayment { get; set; }
        public DateTime PaymentDate { get; set; }

        public override string ToString() =>
            $"PaymentDate: {PaymentDate:d}, InterestPayment: {InterestPayment:f2}, PrincipalPayment {PrincipalPayment:f2}.";
    }
}
