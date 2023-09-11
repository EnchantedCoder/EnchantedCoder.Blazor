namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Context provided to the <see cref="EcSidebarItem.ContentTemplate" />.
/// </summary>
public class SidebarItemContentTemplateContext
{
	/// <summary>
	/// Indicates whether a <see cref="EcSidebarItem"/> is collapsed or expanded. Is <c>null</c> when item has no expandable content.
	/// </summary>
	public bool? ItemExpanded { get; set; }
}
