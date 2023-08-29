﻿using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="HxSelect{TValue, TItem}"/> component.
/// </summary>
public record SelectSettings : InputSettings, IInputSettingsWithSize
{
	/// <summary>
	/// Input size.
	/// </summary>
	public InputSize? InputSize { get; set; }
}