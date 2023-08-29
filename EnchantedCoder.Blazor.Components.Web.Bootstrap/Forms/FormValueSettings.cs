﻿using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="HxFormValue"/> and derived components.
/// </summary>
public record FormValueSettings : IInputSettingsWithSize
{
	/// <summary>
	/// Input size. Default is <see cref="InputSize.Regular"/>.
	/// </summary>
	public InputSize? InputSize { get; set; }
}
