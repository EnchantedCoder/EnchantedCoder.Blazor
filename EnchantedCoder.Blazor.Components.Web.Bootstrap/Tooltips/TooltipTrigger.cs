﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Triggers for <see cref="EcTooltip"/>.
/// </summary>
[Flags]
public enum TooltipTrigger
{
	Click = 1,
	Hover = 2,
	Focus = 4,
	Manual = 8
}
