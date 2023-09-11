using EnchantedCoder.Blazor.Components.Web;            // <------ ADD THIS LINE
using EnchantedCoder.Blazor.Components.Web.Bootstrap;  // <------ ADD THIS LINE

public static async Task Main(string[] args)
{
	var builder = WebAssemblyHostBuilder.CreateDefault(args);
	builder.RootComponents.Add<App>("app");

	// ... shortened for brevity

	builder.Services.AddEcServices();        // <------ ADD THIS LINE

	await builder.Build().RunAsync();
}