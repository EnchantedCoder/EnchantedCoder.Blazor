namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Text content for the <see cref="EcNavbar"/>.
/// </summary>
public partial class EcNavbarText
{
	/// <summary>
	/// Any additional CSS class to apply.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	[Parameter] public RenderFragment ChildContent { get; set; }
}
