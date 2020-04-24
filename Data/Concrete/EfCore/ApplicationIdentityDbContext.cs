
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebUI.Entity;
using WebUI.Models;

namespace WebUI.Data.Concrete.EfCore
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
           : base(options)
        {

        }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PersonalSetting> PersonalSettings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<SocialSetting> SocialSettings { get; set; }
        public DbSet<Image> Images { get; set; }
    }
 

}
