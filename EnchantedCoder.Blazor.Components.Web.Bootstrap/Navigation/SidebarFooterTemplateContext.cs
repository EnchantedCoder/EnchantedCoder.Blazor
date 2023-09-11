namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Context provided to the <see cref="EcSidebar.FooterTemplate" />.
/// </summary>
public class SidebarFooterTemplateContext
{
	/// <summary>
	/// Indicates whether the containing <see cref="EcSidebar"/> is collapsed or expanded.
	/// </summary>
	public bool SidebarCollapsed { get; set; }
}
