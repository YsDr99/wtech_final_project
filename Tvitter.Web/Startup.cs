using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model;
using Tvitter.Service;

namespace Tvitter.Web
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
            services.AddControllersWithViews();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString: Configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(ICoreService<>), typeof(BaseService<>));
            services.AddScoped(typeof(ITweetService<>), typeof(TweetService<>));
            services.AddScoped(typeof(ITagService<>), typeof(TagService<>));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.LoginPath = "/Login"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "Login",
                    defaults: new { controller = "Login", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "signup",
                    pattern: "Signup",
                    defaults: new { controller = "Login", action = "Signup" });
                endpoints.MapControllerRoute(
                    name: "profile",
                    pattern: "{username}",
                    defaults: new { controller = "Profile", action = "UserProfile" });
                endpoints.MapControllerRoute(
                    name: "follower",
                    pattern: "{username}/Followers",
                    defaults: new { controller = "Profile", action = "Followers" });
                endpoints.MapControllerRoute(
                    name: "following",
                    pattern: "{username}/Following",
                    defaults: new { controller = "Profile", action = "Following" });
                endpoints.MapControllerRoute(
                    name: "tweets",
                    pattern: "{username}/Tweets",
                    defaults: new { controller = "Profile", action = "Tweets" });
                endpoints.MapControllerRoute(
                    name: "tweet",
                    pattern: "Tweet/{id}",
                    defaults: new { controller = "Tweet", action = "Index"});
                endpoints.MapControllerRoute(
                   name: "retweet",
                   pattern: "Retweet/{id}",
                   defaults: new { controller = "Tweet", action = "Retweet" });
            });
        }
    }
}
