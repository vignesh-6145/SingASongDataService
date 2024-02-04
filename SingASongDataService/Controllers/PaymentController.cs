using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Data.Carts;
using SingASongDataService.Data.Payments;
using SingASongDataService.Models;

namespace SingASongDataService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController : Controller
    {
        PaymentRepository paymentRepository;
        public PaymentController( )
        {
            this.paymentRepository = new PaymentRepository();   
        }
        [HttpGet]
        [Route("GetAllRecords")]
        public IActionResult GetAllRecords() {
            try
            {
                return Ok(paymentRepository.GetPaymentHistory());
            }catch (Exception ex)
            {
                Console.WriteLine("Failed To Retrieve records");
                Console.WriteLine(ex.Message);
                return BadRequest("Failed To Retrieve records");
            }
        }
        [HttpGet]
        [Route("GetRecord/{PaymentID}")]
        public IActionResult GetPaymentRecord(int PaymentID) {
            try
            {
                Payment payment = paymentRepository.GetPaymentRecord(PaymentID);
                if(payment == null )
                {
                    return NotFound($"No Payment Record with ID : {PaymentID}");
                }
                return Ok( payment );
            }catch (Exception ex)
            {
                Console.WriteLine($"Failed To Retrieve Payment Record with ID : {PaymentID}");
                Console.WriteLine(ex.Message);
                return BadRequest($"Failed To Retrieve Payment Record with ID : {PaymentID}");
            }
        }
        [HttpPost]
        [Route("AddPaymentRecord")]
        public IActionResult RecordPaymentRecord([FromBody] Payment Payment) {
            try
            {
                var result = paymentRepository.RecordPayment(Payment);
                if (result == -1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Somethign went wrong while inserting");
                Console.WriteLine(ex.Message);
                return BadRequest("Failed To Insert");
            }
        }
    }
}
