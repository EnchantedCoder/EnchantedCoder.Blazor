﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace EnchantedCoder.Blazor.GoogleTagManager;

///<summary>
/// Adds Google Tag Manager to the application and manages communication with GTM JavaScript (data-layer).<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcGoogleTagManager">https://EnchantedCoder.blazor.eu/components/EcGoogleTagManager</see>
/// </summary>
/// <inheritdoc/>
public class EcGoogleTagManager : IEcGoogleTagManager, IAsyncDisposable
{
	private readonly EcGoogleTagManagerOptions gtmOptions;
	private readonly NavigationManager navigationManager;
	private readonly IJSRuntime jsRuntime;

	private bool isInitialized;
	private IJSObjectReference jsModule;

	public EcGoogleTagManager(
		IOptions<EcGoogleTagManagerOptions> gtmOptions,
		NavigationManager navigationManager,
		IJSRuntime jsRuntime)
	{
		this.gtmOptions = gtmOptions.Value;
		this.navigationManager = navigationManager;
		this.jsRuntime = jsRuntime;
	}

	/// <inheritdoc/>
	public async Task InitializeAsync()
	{
		if (isInitialized)
		{
			return;
		}

		jsModule ??= await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/EnchantedCoder.Blazor.GoogleTagManager/" + nameof(EcGoogleTagManager) + ".js");

		await jsModule.InvokeVoidAsync("initialize", gtmOptions.GtmId);

		isInitialized = true;
	}

	/// <inheritdoc/>
	public async Task PushAsync(object data)
	{
		await InitializeAsync();
		await jsModule.InvokeVoidAsync("push", data);
	}

	/// <inheritdoc/>
	public async Task PushEventAsync(string eventName, object eventData = null)
	{
		await InitializeAsync();
		await jsModule.InvokeVoidAsync("pushEvent", eventName, eventData);
	}

	/// <inheritdoc/>
	public async Task PushPageViewAsync(object additionalData = null)
	{
		await PushPageViewCoreAsync(navigationManager.Uri, additionalData);
	}

	/// <inheritdoc/>
	async Task IEcGoogleTagManager.PushPageViewAsync(LocationChangedEventArgs args)
	{
		if (args is null)
		{
			// App firstRender
			await PushPageViewAsync();
		}
		else
		{
			await PushPageViewCoreAsync(args.Location, new Dictionary<string, string>() { { "isNavigationIntercepted", args.IsNavigationIntercepted.ToString() } });
		}
	}

	private async Task PushPageViewCoreAsync(string url, object additionalData = null)
	{
		await InitializeAsync();
		await jsModule.InvokeVoidAsync("pushPageViewEvent", gtmOptions.PageViewEventName, gtmOptions.PageViewUrlVariableName, url, additionalData);
	}

	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore();

		//Dispose(disposing: false);
	}

	protected virtual async ValueTask DisposeAsyncCore()
	{
		if (jsModule is not null)
		{
			await jsModule.DisposeAsync();
		}
	}
}
