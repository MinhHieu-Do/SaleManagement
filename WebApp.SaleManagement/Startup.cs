using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;
using WebApp.SaleManagement.DAL;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.Services.IRepository;
using WebApp.SaleManagement.Services.Repository;
using WebApp.WebApp.Services.Repository;
using WebApp.SaleManagement.Middleware;
namespace WebApp.SaleManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SaleDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IAccountInitialize, AccountInitialize>();
            services.AddTransient<IHomeRepository, HomeRepository>();
            //use session
            services.AddSession();
            
            services.AddNotyf(config=>
            {
                config.DurationInSeconds=5;
                config.IsDismissable = true;                
                config.Position = NotyfPosition.TopRight;
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;

            })
                .AddEntityFrameworkStores<SaleDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc();


            services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
                // Đọc thông tin Authentication:Google từ appsettings.json
                IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                // Thiết lập ClientID và ClientSecret để truy cập API google
                googleOptions.ClientId = googleAuthNSection["ClientId"];
                googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                googleOptions.CallbackPath = "/signin-google";

            })
            .AddFacebook(facebookOptions => {
                // Đọc cấu hình
                IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                facebookOptions.AppId = facebookAuthNSection["AppId"];
                facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                // Thiết lập đường dẫn Facebook chuyển hướng đến
                facebookOptions.CallbackPath = "/signin-facebook";
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyAdmin", policy => policy.RequireRole("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAccountInitialize accountInitialize)
        {
            
            if (env.IsDevelopment())
            {
                //app.UseStatusCodePagesWithRedirects("/ErrorPage/{0}");
                //app.UseDeveloperExceptionPage();
                //app.UseMiddlewareErr();
                //app.UseStatusCodePages();
                app.UseStatusCodePages(async context => {
                    if (context.HttpContext.Response.StatusCode == 400)
                    {
                        context.HttpContext.Response.Redirect("https://localhost:44325/ErrorPage/400");
                    }
                    else if (context.HttpContext.Response.StatusCode == 404)
                    {
                        context.HttpContext.Response.Redirect("https://localhost:44325/ErrorPage/404");
                    }
                });
            }
            else
            {
                //app.UseStatusCodePagesWithRedirects("/ErrorPage/{0}");
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            accountInitialize.SeedData();
            app.UseSession();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{id?}");
            });
           

        }
    }
}
