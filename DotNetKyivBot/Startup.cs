using UsefulLinksDuringWarUa.Commands;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ICommandExecutor, CommandExecutor>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<BaseCommand, StartCommand>();
            services.AddSingleton<BaseCommand, InformationSourcesCommand>();
            services.AddSingleton<BaseCommand, EvacuationCommand>();
            services.AddSingleton<BaseCommand, HowToHelpCommand>();
            services.AddSingleton<BaseCommand, HowToSupportCommand>();
            services.AddSingleton<BaseCommand, OnlineMapsCommand>();
            services.AddSingleton<BaseCommand, PsychologicalHelpCommand>();
            services.AddSingleton<IBuildMarkupByButtons, BuildMarkupByButtons>();
            services.AddSingleton<TelegramBot>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            serviceProvider.GetRequiredService<TelegramBot>().GetBot().Wait();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}