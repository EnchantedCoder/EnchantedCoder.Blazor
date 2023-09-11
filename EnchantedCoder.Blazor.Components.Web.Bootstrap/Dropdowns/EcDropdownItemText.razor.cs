namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Text item for the <see cref="EcDropdownMenu"/>.
/// </summary>
public partial class EcDropdownItemText
{
	/// <summary>
	/// Any additional CSS class to apply.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	/// <summary>
	/// Additional CSS class for underlying <c>li</c> container (wrapping the main <c>span</c> inside).
	/// </summary>
	[Parameter] public string ContainerCssClass { get; set; }

	[Parameter] public RenderFragment ChildContent { get; set; }
}
