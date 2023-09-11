using Microsoft.JSInterop;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

public static class JSRuntimeExtensions
{
	internal static ValueTask<IJSObjectReference> ImportEnchantedCoderBlazorBootstrapModuleAsync(this IJSRuntime jsRuntime, string moduleNameWithoutExtension)
	{
		var path = "./_content/EnchantedCoder.Blazor.Components.Web.Bootstrap/" + moduleNameWithoutExtension + ".js?v=" + EcSetup.VersionIdentifierEnchantedCoderBlazorBootstrap;
		return jsRuntime.InvokeAsync<IJSObjectReference>("import", path);
	}
}