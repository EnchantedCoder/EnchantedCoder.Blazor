﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Item for <see cref="EcListGroup"/>.
/// </summary>
public partial class EcListGroupItem
{
	/// <summary>
	/// Content of the item.
	/// </summary>
	[Parameter] public RenderFragment ChildContent { get; set; }

	/// <summary>
	/// Indicates the current active selection.
	/// </summary>
	[Parameter] public bool Active { get; set; }

	/// <summary>
	/// Make the item appear disabled by setting to <c>false</c>.
	/// Default is <c>true</c>.
	/// </summary>
	[Parameter] public bool Enabled { get; set; } = true;

	/// <summary>
	/// Color.
	/// </summary>
	[Parameter] public ThemeColor? Color { get; set; }

	/// <summary>
	/// An event that is fired when the <c>EcListGroupItem</c> is clicked.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
	/// <summary>
	/// Triggers the <see cref="OnClick"/> event. Allows interception of the event in derived components.
	/// </summary>
	protected virtual Task InvokeOnClickAsync(MouseEventArgs args) => OnClick.InvokeAsync(args);

	/// <summary>
	/// Additional CSS class.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	[CascadingParameter] protected EcListGroup ListGroupContainer { get; set; }

	private string GetClasses()
	{
		return CssClassHelper.Combine(
			"list-group-item",
			Active ? "active" : null,
			Enabled ? null : "disabled",
			OnClick.HasDelegate ? "list-group-item-action" : null,
			GetColorCssClass(),
			this.CssClass);
	}

	private string GetColorCssClass()
	{
		return Color switch
		{
			null => null,
			ThemeColor.None => null,
			_ => "list-group-item-" + this.Color.Value.ToString("f").ToLower()
		};
	}
}
