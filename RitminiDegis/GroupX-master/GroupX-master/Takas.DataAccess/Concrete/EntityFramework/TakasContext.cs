using System.Data.Entity;
using Takas.Common.Entities.Concrete;


namespace Takas.DataAccess.Concrete.EntityFramework
{
	public class TakasContext : DbContext
	{

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Exchange> Exchanges { get; set; }
		public virtual DbSet<Favorite> Favourites { get; set; }
		public virtual DbSet<Message> Messages { get; set; }
		public virtual DbSet<ProductImageGallery> ProductImageGalleries { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<Token> Tokens { get; set; }
		public virtual DbSet<UserComment> UserComments { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<SocialUser> SocialUsers { get; set; }
		public virtual DbSet<WebApiTokenKey> WebApiTokenKeys { get; set; }

	}
}
