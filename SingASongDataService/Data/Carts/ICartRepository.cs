using SingASongDataService.Models;
using System.Net;

namespace SingASongDataService.Data.Carts
{
    public interface ICartRepository
    {
        public Cart GetCart(int CartID);
        public IEnumerable<Track> GetTracks(int UserID);
        public Cart GetUserCart(int UserID);
        public bool CreateCart(int UserID);
        public IEnumerable<Cart> GetCarts();
        public bool AddToCart(int UserId, int TrackID);
        public bool RemoveFromCart(int UserID, int TrackID);
        public decimal GetCartTotal(int UserID);

        public bool DisableCart(int UserID);
    }
}
