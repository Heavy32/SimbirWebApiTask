using BusinessLogic;
using BusinessLogic.OrderManagement;
using BusinessLogic.ShavermaManagement;
using BusinessLogic.UserManagement;
using Data;
using Data.OrderEmbeddedData;
using Data.ShavermaEmbeddedData;
using Data.UserEmbeddedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirWebApiTask
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IMapper, AutoMapperImplementation>();
            services.AddSingleton<IServiceResultStatusToResponseConverter, ServiceResultCodeToResponseConverter>();

            services.AddTransient<IUserCRUDService, UserCRUDService>();
            services.AddTransient<IShavermaCRUDService, ShavermaCRUDService>();
            services.AddTransient<IOrderCRUDService, OrderCRUDService>();

            services.AddSingleton<IDataProvider<UserDataModel>, UserListDataProvider>();
            services.AddSingleton<IDataProvider<ShavermaDataModel>, ShavermaListDataProvider>();
            services.AddSingleton<IDataProvider<OrderDataModel>, OrderListDataProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
