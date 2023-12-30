using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
//24feb/0:14:00 jätk
    public DbSet<Courses> Courses { get; set; } = default!;
    public DbSet<GroupJoinRequests> GroupJoinRequests {get; set; } = default!;
    public DbSet<GroupMeetings> GroupMeetings { get; set; } = default!;
    public DbSet<GroupMessages> GroupMessages {get; set; } = default!;
    public DbSet<Notifications> Notifications {get; set; } = default!;
    public DbSet<Remainders> Remainders { get; set; } = default!;
    public DbSet<StudyGroups> StudyGroups { get; set; } = default!;
    public DbSet<UserAvailabilities> UserAvailabilities { get; set; } = default!;
    public DbSet<UserCourses> UserCourses { get; set; } = default!;
    public DbSet<UserStudyGroups> UserStudyGroups { get; set; } = default!;
    public DbSet<RoleWithinGroup> RolesWithinGroup { get; set; } = default!;
    
    public DbSet<AppRefreshToken> AppRefreshTokens { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // let the initial stuff run
        base.OnModelCreating(builder);

        // disable cascade delete
        foreach (var foreignKey in builder.Model
                     .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

}