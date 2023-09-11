namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// <see href="https://getbootstrap.com/docs/5.3/components/dropdowns/#headers">Dropdown menu header</see> for <see cref="EcDropdownMenu"/>.
/// </summary>
public partial class EcDropdownHeader
{
	/// <summary>
	/// Any additional CSS class to apply.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	[Parameter] public RenderFragment ChildContent { get; set; }
}
