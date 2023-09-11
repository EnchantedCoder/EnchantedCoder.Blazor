﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// <see cref="EcTabPanel"/> render mode.
/// </summary>
public enum TabPanelRenderMode
{
	/// <summary>
	/// Content of all tabs is always rendered (and visibility set with CSS).
	/// </summary>
	AllTabs = 0,

	/// <summary>
	/// Tab content is rendered only when it is active.
	/// </summary>
	ActiveTabOnly = 1
}
