using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution.Configuration;
using HotChocolate.Subscriptions;
using StarWars.Models;

namespace StarWars
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add in-memory event provider
            services.AddInMemorySubscriptionProvider();

            // Add GraphQL Services
            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)    
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()

                // would like to add an interferred union of ICharacter 
                .AddUnionType<ICharacter>()

                // need to add this, otherwise exception... makes sense
                .AddType<Human>()
                .AddType<Droid>()
                
                // we would also like Human and Droid to be an input type... commented out Droid to make it working... notice the union changes
                .AddInputObjectType<Human>()
                //.AddInputObjectType<Droid>()
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground();
        }
    }
}
