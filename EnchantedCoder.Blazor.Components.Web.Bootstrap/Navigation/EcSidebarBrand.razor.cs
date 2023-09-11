namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Brand for the <see cref="EcSidebar.HeaderTemplate"/>.
/// </summary>
public partial class EcSidebarBrand
{
	/// <summary>
	/// Brand long name.
	/// </summary>
	[Parameter] public string BrandName { get; set; }

	/// <summary>
	/// Brand logo.
	/// </summary>
	[Parameter] public RenderFragment<SidebarBrandLogoTemplateContext> LogoTemplate { get; set; }

	/// <summary>
	/// Brand short name.
	/// </summary>
	[Parameter] public string BrandNameShort { get; set; }

	/// <summary>
	/// <see cref="EcSidebar"/> containing the <see cref="EcSidebarBrand"/>.
	/// </summary>
	[CascadingParameter] protected EcSidebar ParentSidebar { get; set; }

	protected override void OnParametersSet()
	{
		Contract.Requires<InvalidOperationException>(ParentSidebar is not null, $"{nameof(EcSidebarBrand)} has to be placed inside {nameof(EcSidebar)}.");
	}
}
