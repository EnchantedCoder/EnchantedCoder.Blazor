using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace EnchantedCoder.Blazor.GoogleTagManager;

public static class GoogleTagManagerServiceCollectionExtensions
{
	/// <summary>
	/// Adds Google Tag Mananger (GTM) support. Use <see cref="IEcGoogleTagManager"/> to push data to <c>dataLayer</c> and/or <see cref="EcGoogleTagManagerPageViewTracker"/> to track page-views.
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configureOptions"></param>
	/// <returns></returns>
	public static IServiceCollection AddEcGoogleTagManager(this IServiceCollection services, Action<EcGoogleTagManagerOptions> configureOptions)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser")))
		{
			services.AddSingleton<IEcGoogleTagManager, EcGoogleTagManager>();
		}
		else
		{
			services.AddScoped<IEcGoogleTagManager, EcGoogleTagManager>();
		}

		if (configureOptions != null)
		{
			services.Configure(configureOptions);
		}

		return services;
	}

}
