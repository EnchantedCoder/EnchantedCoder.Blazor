﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Placement of the popover for <see cref="HxPopover"/>.
/// </summary>
public enum PopoverPlacement
{
	Top = TooltipPlacement.Top,
	Bottom = TooltipPlacement.Bottom,
	Left = TooltipPlacement.Left,
	Right = TooltipPlacement.Right,

	/// <summary>
	/// When is specified, it will dynamically reorient the popover.
	/// </summary>
	Auto = TooltipPlacement.Auto
}
