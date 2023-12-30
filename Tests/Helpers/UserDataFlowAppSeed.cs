using DAL.EF.App;
using Microsoft.AspNetCore.Identity;

namespace Tests.Helpers;

public class UserDataFlowAppSeed
{
     public Guid adminId = Guid.Parse("432123b4-cc31-4b64-bd83-3c6d7228c5e2");

    public Domain.App.Identity.AppUser? UserData { get; set; }
    
    public Domain.App.Courses? CoursesData { get; set; }


    public UserDataFlowAppSeed(UserManager<Domain.App.Identity.AppUser> userManager,
        RoleManager<Domain.App.Identity.AppRole> roleManager,
        ApplicationDbContext context)
    {
        SeedIdentity(userManager, roleManager);

        SeedAppData(context);
    }

    public void SeedIdentity(UserManager<Domain.App.Identity.AppUser> userManager,
        RoleManager<Domain.App.Identity.AppRole> roleManager)
    {
        (Guid id, string email, string pwd) userData = (adminId, "admin@app.com", "Foo.bar.1");

        var user = userManager.FindByEmailAsync(userData.email).Result;

        if (user == null)
        {
            user = new Domain.App.Identity.AppUser()
            {
                Id = userData.id,
                Email = userData.email,
                UserName = userData.email,
                FirstName = "Admin",
                LastName = "nimda",
                EmailConfirmed = true,
            };

            var result = userManager.CreateAsync(user, userData.pwd).Result;

            if (!result.Succeeded)
            {
                throw new ApplicationException($"Cannot seed users, {result.ToString()}");
            }
        }

        UserData = userManager.FindByEmailAsync(userData.email).Result;
    }

    public void SeedAppData(ApplicationDbContext context)
    {
        CoursesData = new Domain.App.Courses()
        {
            Id = Guid.NewGuid(),
            CourseName = "Füüsika",
            CourseCode = "Icd0001",
        };

       
        context.Courses.Add(CoursesData);

        context.SaveChanges();
    }
}