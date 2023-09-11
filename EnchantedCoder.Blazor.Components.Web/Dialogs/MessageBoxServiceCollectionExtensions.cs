using Microsoft.Extensions.DependencyInjection;

namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// Extension methods for installation of <see cref="IEcMessageBoxService"/> support.
/// </summary>
public static class MessageBoxServiceCollectionExtensions
{
	/// <summary>
	/// Adds <see cref="IEcMessageBoxService"/> support to be able to display message boxes using EcMessageBoxHost.
	/// </summary>
	public static IServiceCollection AddEcMessageBoxHost(this IServiceCollection services)
	{
		return services.AddScoped<IEcMessageBoxService, EcMessageBoxService>();
	}
}
