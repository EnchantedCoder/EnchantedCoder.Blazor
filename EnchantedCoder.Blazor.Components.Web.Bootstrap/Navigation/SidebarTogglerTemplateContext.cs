﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Context provided to the <see cref="HxSidebar.TogglerTemplate" />.
/// </summary>
public class SidebarTogglerTemplateContext
{
	/// <summary>
	/// Indicates whether a <see cref="HxSidebar"/> is collapsed or expanded.
	/// </summary>
	public bool SidebarCollapsed { get; set; }
}
