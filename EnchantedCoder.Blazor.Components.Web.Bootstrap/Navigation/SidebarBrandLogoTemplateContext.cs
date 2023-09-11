namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Context provided to the <see cref="EcSidebarBrand.LogoTemplate" />.
/// </summary>
public class SidebarBrandLogoTemplateContext
{
	/// <summary>
	/// Indicates whether a <see cref="EcSidebar"/> is collapsed or expanded.
	/// </summary>
	public bool SidebarCollapsed { get; set; }
}
