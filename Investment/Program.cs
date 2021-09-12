namespace Investments
{
    internal class Program
    {
        private static void Main()
        {
            var userInteraction = new UserInteraction();
            var loan = userInteraction.GetLoan();
            var annuityPaymentService = new AnnuityPaymentService();
            annuityPaymentService.CalculatePayments(loan);

            while (true)
            {
                var request = userInteraction.GetCalculationRequest();
                if (request == null)
                {
                    return;
                }

                var result = annuityPaymentService.Calculate(request, loan);
                userInteraction.ShowCalculationResult(result);
            }
        }
    }
}
