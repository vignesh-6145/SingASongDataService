using Azure.Identity;
using SingASongDataService.Models;

namespace SingASongDataService.Data.Carts
{
    public class CartRepository : ICartRepository
    {
        SingASongContext _context;
        public CartRepository()
        {
            this._context = new SingASongContext();
        }
        public Cart GetCart(int CartID)
        {
            Cart Cart = _context.Carts.First(cart => cart.CartId == CartID);
            return Cart;
        }
        public IEnumerable<Cart> GetCarts()
        {
            return _context.Carts;
        }
        public Cart GetUserCart(int UserID)
        {
            return _context.Carts.FirstOrDefault(record => record.UserId == UserID && record.Status == 1);
        }

        public bool CreateCart(int UserID)
        {
            try
            {

                Cart cart = new Cart();
                cart.UserId = UserID;
                cart.Status = 1;
                _context.Carts.Add(cart);
                _context.SaveChanges();
                Console.WriteLine($"Cart created for User with ID : {UserID}");
                return true;
            }catch (Exception ex) {
                Console.WriteLine("Failed to create Cart");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddToCart(int UserID, int  TrackID)
        {
            try
            {
                //Check if thres any active cart, if not create one active cart and add to it
                Cart Cart = _context.Carts.FirstOrDefault(record => record.UserId==UserID && record.Status==1);
                if (Cart == null)
                {
                    Console.WriteLine("No Existing Active Cart Found, Creating One!!");
                    Cart = new Cart();
                    Cart.UserId = UserID;
                    Cart.Status = 1;
                    _context.Carts.Add(Cart) ;
                    _context.SaveChanges();
                    Cart = _context.Carts.First(record => record.UserId == UserID && record.Status == 1);
                }
                CartTrack CartTrack = new CartTrack();
                CartTrack.CartId = Cart.CartId;
                CartTrack.TrackId = TrackID;
                _context.CartTracks.Add(CartTrack);
                _context.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool RemoveFromCart(int UserID, int TrckID)
        {
            //Check if he has actuall cart or not
            Cart? cart = _context.Carts.FirstOrDefault(record => record.UserId==UserID && record.Status==1);
            if (cart == null)
            {
                Console.WriteLine("User has no active Cart"); return false;
            }
            CartTrack? cartTrack = _context.CartTracks.FirstOrDefault(
                    record =>
                        record.CartId == cart.CartId
                        && record.TrackId == TrckID);
            if (cartTrack == null) {
                Console.WriteLine($"Track not present in his cart {cart.CartId}");
                return false;
            }
            _context.CartTracks.Remove(cartTrack);
            _context.SaveChanges();
            return true;

               //check if cart has the track or not
                 //Remove the record
               //Print the informatino
            //Print the error info
        }

        public decimal GetCartTotal(int UserID)
        {
            Cart cart = GetUserCart(UserID);
            if(cart == null)
            {
                Console.WriteLine($"User {UserID} has no Active Cart");
                return 0;
            }
            var trackIDs = _context.CartTracks.Where(record => record.CartId==cart.CartId).Select(record => record.TrackId).ToList();
            decimal total = 0;
            foreach (var track in trackIDs)
            {

                Track trck = _context.Tracks.FirstOrDefault(record => record.TrackId == track);
                total += trck.Price;
            }
            return total;
        }

        public bool DisableCart(int UserId)
        {
            Cart cart = GetUserCart(UserId); 
            if(cart == null) {
                Console.WriteLine($"User : {UserId} has no active cart to disables");
                return false;
            }

            cart.Status = 0;
            _context.Carts.Update(cart);
            _context.SaveChanges();
            return true;

        }
        
        public IEnumerable<Track> GetTracks(int UserID)
        {
            //Check IF user Has active cart
            Cart cart = GetUserCart(UserID);
            if(cart == null) {
                Console.WriteLine("No Active Cart Found");
                return null;
            }
            IEnumerable<int> trackIDs = _context.CartTracks.Where(record => record.CartId == cart.CartId).Select(record => record.TrackId).ToList();
            List<Track> tracks = new List<Track>();
            foreach (var track in trackIDs)
            {
                tracks.Add(_context.Tracks.FirstOrDefault(trck => trck.TrackId==track));
            }
            return tracks;
        }
    }
}
