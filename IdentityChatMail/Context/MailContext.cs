using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatMail.Context
{
    public class MailContext:IdentityDbContext<AppUser>//benim ozellestirdigim sinifi da al !
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MULUSOY\\SQLEXPRESS01;Initial Catalog=LessonTwoDb;integrated Security=true; trust server certificate=true");
        }
    }
}
