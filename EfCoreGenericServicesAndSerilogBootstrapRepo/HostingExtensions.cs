using EfCoreGenericServicesAndSerilogBootstrapRepo.Data;
using GenericServices.Setup;
using Microsoft.EntityFrameworkCore;

namespace EfCoreGenericServicesAndSerilogBootstrapRepo
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("PeopleDb");

                // Uncommenting this works around the issue but disables logging for the context.
                //options.UseLoggerFactory(NullLoggerFactory.Instance);
            });

            builder.Services.GenericServicesSimpleSetup<ApplicationDbContext>(typeof(Program).Assembly);

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            return app;
        }
    }
}