using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace EnchantedCoder.Blazor.GoogleTagManager;

public class EcGoogleTagManagerPageViewTracker : ComponentBase, IDisposable
{
	[Inject] protected NavigationManager NavigationManager { get; set; }
	[Inject] protected IEcGoogleTagManager EcGoogleTagManager { get; set; }

	private LocationChangedEventArgs locationChangedEventArgsToReportOnAfterRenderAsync;

	protected override void OnInitialized()
	{
		base.OnInitialized();

		NavigationManager.LocationChanged += OnLocationChanged;
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender || (locationChangedEventArgsToReportOnAfterRenderAsync is not null))
		{
			var argsToReport = locationChangedEventArgsToReportOnAfterRenderAsync;
			locationChangedEventArgsToReportOnAfterRenderAsync = null;
			await EcGoogleTagManager.PushPageViewAsync(argsToReport);
		}

		await base.OnAfterRenderAsync(firstRender);
	}

	private void OnLocationChanged(object sender, LocationChangedEventArgs args)
	{
		locationChangedEventArgsToReportOnAfterRenderAsync = args;
		StateHasChanged();
	}

	public void Dispose()
	{
		Dispose(true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			NavigationManager.LocationChanged -= OnLocationChanged;
		}
	}
}
