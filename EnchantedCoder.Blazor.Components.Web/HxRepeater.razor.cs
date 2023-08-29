﻿namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// A data-bound list component that allows custom layout by repeating a specified template for each item displayed in the list.
/// Analogous to ASP.NET WebForms Repeater control.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/HxRepeater">https://EnchantedCoder.blazor.eu/components/HxRepeater</see>
/// </summary>
/// <typeparam name="TItem">item type</typeparam>
public partial class HxRepeater<TItem> : ComponentBase
{
	/// <summary>
	/// Template that defines how the header section of the Repeater component is displayed.
	/// Renders only if there are any items to display.
	/// </summary>
	[Parameter] public RenderFragment HeaderTemplate { get; set; }

	/// <summary>
	/// Template that defines how items in the Repeater component are displayed.
	/// </summary>
	[Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }

	/// <summary>
	/// Template that defines how the footer section of the Repeater component is displayed.
	/// Renders only if there are any items to display.
	/// </summary>
	[Parameter] public RenderFragment FooterTemplate { get; set; }

	/// <summary>
	/// Template that defines what should be rendered in case of Items <c>null</c>.
	/// </summary>
	[Parameter] public RenderFragment NullTemplate { get; set; }

	/// <summary>
	/// Template that defines what should be rendered in case of empty Items.
	/// </summary>
	[Parameter] public RenderFragment EmptyTemplate { get; set; }

	/// <summary>
	/// Items to be rendered.
	/// </summary>
	[Parameter, EditorRequired] public IEnumerable<TItem> Data { get; set; }
}
