using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared;

public partial class MainLayout
{
	private const string TitleBase = "EnchantedCoder Blazor - Free Bootstrap 5 components";
	private const string TitleSeparator = " | ";

	[Inject] protected NavigationManager NavigationManager { get; set; }

	private string title;

	protected override void OnParametersSet()
	{
		var path = new Uri(this.NavigationManager.Uri).AbsolutePath.TrimEnd('/');

		var lastSegmentStart = path.LastIndexOf("/");
		if (lastSegmentStart > 0)
		{
			title = path.Substring(lastSegmentStart + 1) + TitleSeparator + TitleBase;
			return;
		}

		title = "EnchantedCoder Blazor | Free Bootstrap 5 components for Blazor";
	}
}
