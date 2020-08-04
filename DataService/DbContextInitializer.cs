using FunctionalService;
using ModelService;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DataService
{
    public static class DbContextInitializer
    {
        
        public static async Task Initialize(ApplicationDbContext applicationDbContext, IFunctionalSvc functionalSvc)
        {
            // Check, if db ApplicationDbContext is created
            await applicationDbContext.Database.EnsureCreatedAsync();

            // Check, if db contains any users. If db is not empty, then db has been already seeded
            if (applicationDbContext.Users.Any())
            {
                return;
            }
            
            // If empty create Default User
            await applicationDbContext.Users.AddAsync(new User { FirstName="Tâm", UserName="tammx.ldg", Password= functionalSvc.GetMd5Hash(MD5.Create(), "12345").Result, UserType = "Admin"});
            await applicationDbContext.Users.AddAsync(new User { FirstName = "Tâm 2", UserName = "tammx2.ldg", Password = functionalSvc.GetMd5Hash(MD5.Create(), "123").Result, UserType = "User" });
            await applicationDbContext.SaveChangesAsync();

        }
    }
}
