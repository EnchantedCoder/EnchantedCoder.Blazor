using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// Extension methods for installation of EcMessenger support.
/// </summary>
public static class MessengerServiceCollectionExtensions
{
	/// <summary>
	/// Adds <see cref="IEcMessengerService"/> support to be able to add messages to EcMessenger.
	/// </summary>
	public static IServiceCollection AddEcMessenger(this IServiceCollection services)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
		{
			// allows gRPC Interceptors and HttpMessageHandlers to pass error-messages to the EcMessenger without having to struggle with different DI Scope
			return services.AddSingleton<IEcMessengerService, EcMessengerService>();
		}
		else
		{
			return services.AddScoped<IEcMessengerService, EcMessengerService>();
		}
	}
}
