using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Data.Carts;
using SingASongDataService.Models;

namespace SingASongDataService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CartController : Controller
    {
        CartRepository cartRepository;
        public CartController() {
            this.cartRepository = new CartRepository();
        }
        [HttpGet]
        [Route("AllCarts")]
        public IActionResult GetCarts()
        {
            return Ok(cartRepository.GetCarts());
        }
        [HttpGet]
        [Route("{CartID}")]
        public IActionResult GetCart(int CartID)
        {
            Cart cart = cartRepository.GetCart(CartID);
            if (cart == null)
            {
                return NotFound($"No Cart with ID : {CartID}");
            }
            return Ok(cart);
        }
        [HttpGet]
        [Route("User/{UserID}")]
        public IActionResult GetUserCart(int UserID)
        {
            Cart cart = cartRepository.GetUserCart(UserID);
            if (cart == null)
            {
                return NotFound("User Cart was empty");
            }
            return Ok(cart);
        }

        [HttpGet]
        [Route("Create/{UserID}")]
        public IActionResult CreateCart(int UserID)
        {
            var result = cartRepository.CreateCart(UserID);
            if (result) return Ok("User Cart was Intitiated");
            else return BadRequest("Failed to create Cart");
        }

        [HttpPost]
        [Route("User/{UserID}/AddToCart/{TrackID}")]
        public IActionResult AddToCart(int UserID, int TrackID)
        {
            var result = cartRepository.AddToCart(UserID, TrackID);
            if (result) return Ok("Item Added to the Cart");
            else return BadRequest("Sorry, Some thing went wrong");
        }
        [HttpDelete]
        [Route("User/{UserID}/RemoveFromCart/{TrackID}")]
        public IActionResult RemoveFromCart(int UserID, int TrackID)
        {
            var result = cartRepository.RemoveFromCart(UserID, TrackID);
            if (result) return Ok("Track Removed From Cart");
            else return BadRequest("Action was not succesfull");
        }

        [HttpGet]
        [Route("{UserID}/GetTotalPrice")]
        public IActionResult GetTotalPrice(int UserID)
        {
            return Ok(cartRepository.GetCartTotal(UserID));
        }

        [HttpDelete]
        [Route("DisableCart/{UserID}")]
        public IActionResult DisableCart(int UserID)
        {
            var result = cartRepository.DisableCart(UserID);
            if (result) return Ok("Cart Disabled Successfully");
            else return BadRequest("Bad Request");
        }
        [HttpGet]
        [Route("User/{UserID}/GetTracks")]
        public IActionResult GetCartTracks(int UserID)
        {
            IEnumerable<Track> tracks = cartRepository.GetTracks(UserID);
            if (tracks == null) return NotFound("User didn't add any tracks");
            else return Ok(tracks);
        }
    }
}
