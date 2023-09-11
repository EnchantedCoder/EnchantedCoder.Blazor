namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Context provided to the <see cref="EcSidebar.TogglerTemplate" />.
/// </summary>
public class SidebarTogglerTemplateContext
{
	/// <summary>
	/// Indicates whether a <see cref="EcSidebar"/> is collapsed or expanded.
	/// </summary>
	public bool SidebarCollapsed { get; set; }
}
