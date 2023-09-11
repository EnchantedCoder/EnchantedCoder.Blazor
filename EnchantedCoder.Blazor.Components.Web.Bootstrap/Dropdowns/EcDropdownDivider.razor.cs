namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Divider for the <see cref="EcDropdownMenu"/>.
/// </summary>
public partial class EcDropdownDivider
{
	/// <summary>
	/// Additional CSS class for underlying <c>li&gt;hr</c> element.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	/// <summary>
	/// Additional CSS class for underlying <c>li</c> container (wrapping the main <c>hr</c> inside).
	/// </summary>
	[Parameter] public string ContainerCssClass { get; set; }
}
