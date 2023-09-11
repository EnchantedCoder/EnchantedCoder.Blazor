using Microsoft.Extensions.DependencyInjection;

namespace EnchantedCoder.Blazor.Components.Web;

public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds services needed for EnchantedCoder Blazor library.
	/// </summary>
	public static IServiceCollection AddEcServices(this IServiceCollection services)
	{
		services.AddLocalization();

		return services;
	}
}
