using Microsoft.EntityFrameworkCore;
using SoccerWebAPI.Contexts;
using SoccerWebAPI.Services.Repositories;
using SoccerWebAPI.Services.UnitsOfWork;

namespace SoccerWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["ConnectionStrings:TeamsDBConnectionString"];
            builder.Services.AddDbContext<TeamsContext>(o => o.UseSqlServer(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICoachRepository, CoachRepository>();
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();

            builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            builder.Services.AddScoped<ITeamUnitOfWork, TeamUnitOfWork>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void Configure(WebApplication app)
        {
            //Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }
    }
}
