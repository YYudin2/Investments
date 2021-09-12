using System;
using System.Collections.Generic;

namespace Investments
{
    internal class CalculationResult
    {
        public Loan Loan { get; set; }
        public List<Payment> Payments { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
