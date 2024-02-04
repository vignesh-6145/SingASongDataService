using SingASongDataService.Models;

namespace SingASongDataService.Data.Payments
{
    public interface IPaymentsRepository
    {
        public Payment GetPaymentRecord(int _);
        public IEnumerable<Payment> GetPaymentHistory();
        public int RecordPayment(Payment _);

        public bool PushToUserList(int UserId);
    }
}
