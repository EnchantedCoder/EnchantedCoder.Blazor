﻿using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="EcInputText"/> and derived components.
/// </summary>
public record InputTextSettings : InputSettings, IInputSettingsWithSize
{
	/// <summary>
	/// Input size.
	/// </summary>
	public InputSize? InputSize { get; set; }

	/// <summary>
	/// Hint to browsers as to the type of virtual keyboard configuration to use when editing.
	/// </summary>
	public InputMode? InputMode { get; set; }
}