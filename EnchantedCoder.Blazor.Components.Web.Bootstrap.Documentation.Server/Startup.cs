using System.Globalization;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.DemoData;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components.DocColorMode;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Server;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages();
		services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddEcServices();
		services.AddEcMessenger();
		services.AddEcMessageBoxHost();

		services.AddTransient<IComponentApiDocModelBuilder, ComponentApiDocModelBuilder>();
		services.AddSingleton<IDocXmlProvider, DocXmlProvider>();
		services.AddSingleton<IDocPageNavigationItemsHolder, DocPageNavigationItemsHolder>();
		services.AddTransient<IDocColorModeResolver, DocColorModeServerResolver>();

		services.AddTransient<IDemoDataService, DemoDataService>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		var cultureInfo = new CultureInfo("en-US");
		CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
		CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseWebAssemblyDebugging();
		}
		else
		{
			app.UseExceptionHandler("/Error");

			// old domain redirect
			app.Use(async (context, next) =>
			{

				if (context.Request.Host.Host.Contains("EnchantedCoder.blazor.cz"))
				{
					var uriBuilder = new UriBuilder(UriHelper.GetDisplayUrl(context.Request));
					uriBuilder.Host = "EnchantedCoder.blazor.eu";
					context.Response.Redirect(uriBuilder.Uri.ToString(), permanent: true);

					return;
				}

				await next();
			});
		}

		app.UseBlazorFrameworkFiles();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapRazorPages();
			endpoints.MapControllers();
			endpoints.MapFallbackToPage("/_Host");
		});
	}
}