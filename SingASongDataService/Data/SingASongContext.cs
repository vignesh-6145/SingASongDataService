using Microsoft.EntityFrameworkCore;
using SingASongDataService.Models;

namespace SingASongDataService.Data
{
    public class SingASongContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartTrack> CartTracks { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Coupon> Coupons { get; set; } = null!;
        public DbSet<DisountsInfo> disountsInfo { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<Subscriber> Subscribers { get; set; } = null!; 
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!;

        public DbSet<TracKArtists> TracKArtists { get; set; } = null!;
        public DbSet<TrackGenres> TrackGenres { get; set; } = null!;
        public DbSet<UserTracks> UserTracks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=C1-BPFK114-L\SQLEXPRESS;Initial Catalog=SingASongP;Integrated Security=True;Trust Server Certificate=True");
        }

    }
}
