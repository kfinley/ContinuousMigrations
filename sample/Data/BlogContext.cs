using Microsoft.EntityFrameworkCore;

using Entities;

namespace Data {
    public class BlogContext : DbContext {

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Configuration<Blog>());
            builder.ApplyConfiguration(new Configuration<Author>());
        }
    }
}