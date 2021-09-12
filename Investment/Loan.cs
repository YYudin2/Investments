using System;
using System.Collections.Generic;

namespace Investments
{
    internal class Loan
    {
        public double Principal { get; set; }
        public DateTime MaturityDate { get; set; }
        public double Rate { get; set; }
        public DateTime IssueDate { get; set; }
        public List<Payment> Payments { get; set; }

        public void Deconstruct(out double principal, out DateTime maturityDate, out double rate, out DateTime issueDate)
        {
            principal = Principal;
            maturityDate = MaturityDate;
            rate = Rate;
            issueDate = IssueDate;
        }

        public override string ToString() =>
            $"Loan, Principal: {Principal:f2}, IssueDate: {IssueDate:d}, MaturityDate: {MaturityDate:d}, Rate: {Rate:f2}";
    }
}
