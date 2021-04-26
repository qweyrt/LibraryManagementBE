
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Services.Book;
using LibraryManagement.Services.Category;
using LibraryManagement.Services.Request;
using LibraryManagement.Services.RequestDetails;
using LibraryManagement.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod();
                                  });
            });
            services.AddControllers()
                .AddNewtonsoftJson(opts =>
                                       opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            services.AddDbContext<LibraryManagementDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LibraryDbContextConnection")));
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IRequestDetailsService, RequestDetailsService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibManagement", Version = "v1" });
            });
            services.Configure<CookiePolicyOptions>(option =>
            {
                option.CheckConsentNeeded = context => true;
                option.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibManagement v1"));
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
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
