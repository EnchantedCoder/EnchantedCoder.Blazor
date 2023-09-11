﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Options for controlling the behavior of the <see cref="EcModal.Backdrop"/>.
/// </summary>
public enum ModalBackdrop
{
	/// <summary>
	/// A backdrop will be rendered. Modal will be closed upon clicking on the backdrop.
	/// </summary>
	True = 0,

	/// <summary>
	/// No backdrop will be rendered.
	/// </summary>
	False = 1,

	/// <summary>
	/// A static backdrop will be rendered. Modal will not be closed upon clicking on the backdrop.
	/// </summary>
	Static = 2
}
