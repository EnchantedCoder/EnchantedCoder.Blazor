using System.Globalization;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.DemoData;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components.DocColorMode;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);

		var cultureInfo = new CultureInfo("en-US");
		CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
		CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

		builder.Services.AddEcServices();
		builder.Services.AddEcMessenger();
		builder.Services.AddEcMessageBoxHost();

		builder.Services.AddTransient<IComponentApiDocModelBuilder, ComponentApiDocModelBuilder>();
		builder.Services.AddSingleton<IDocXmlProvider, DocXmlProvider>();
		builder.Services.AddSingleton<IDocPageNavigationItemsHolder, DocPageNavigationItemsHolder>();
		builder.Services.AddSingleton<IDocColorModeResolver, DocColorModeClientResolver>();

		builder.Services.AddTransient<IDemoDataService, DemoDataService>();

		await builder.Build().RunAsync();
	}
}
