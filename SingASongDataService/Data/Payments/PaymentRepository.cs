using SingASongDataService.Models;

namespace SingASongDataService.Data.Payments
{
    public class PaymentRepository:IPaymentsRepository
    {
        SingASongContext _context;  
        public PaymentRepository()
        {
            _context = new SingASongContext();
        }
        public IEnumerable<Payment> GetPaymentHistory() {
            return _context.Payments;
        }
        public Payment GetPaymentRecord(int PaymentID)
        {
            try
            {
                return _context.Payments.First(record => record.PaymentId == PaymentID);
            }catch (Exception ex)
            {
                Console.WriteLine($"No Payment Record with ID {PaymentID}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool PushToUserList(int PaymentID)
        {
            try
            {
                int cartId = _context.Payments.First(record => record.PaymentId == PaymentID).CartID;
                int userID = _context.Carts.First(crt => crt.CartId==cartId).UserId;
                List<int> trackIDs = _context.CartTracks
                                            .Where(record => record.CartId==cartId)
                                            .Select(record => record.TrackId).ToList();
                foreach (int trackID in trackIDs)
                {
                    _context.UserTracks.Add(new()
                    {
                        UserId = userID,
                        TrackID = trackID
                    });
                }
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) {
                Console.WriteLine($"No Payment Record with ID : {PaymentID}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public int RecordPayment(Payment Payment)
        {
            try
            {
                _context.Payments.Add(Payment);
                _context.SaveChanges();
                if (Payment.PurchaseStatus == PaymentStatus.Success)
                {
                    PushToUserList(Payment.PaymentId);
                }
                return Payment.PaymentId;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something WentWrong");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
