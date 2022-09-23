﻿using Havit.Blazor.Components.Web.Infrastructure;

namespace Havit.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Base class for HxRadioList and custom-implemented pickers.
/// </summary>
/// <typeparam name="TValue">Type of value.</typeparam>
/// <typeparam name="TItem">Type of items.</typeparam>
public abstract class HxRadioButtonListBase<TValue, TItem> : HxInputBase<TValue>
{
	/// <summary>
	/// Allows grouping radios on the same horizontal row by rendering them inline. Default is <c>false</c>.
	/// </summary>
	[Parameter] public bool Inline { get; set; }

	/// <summary>
	/// Selects value from item.
	/// Not required when TValueType is same as TItemTime.
	/// Base property for direct setup or to be re-published as <c>[Parameter] public</c>.
	/// </summary>
	protected Func<TItem, TValue> ValueSelectorImpl { get; set; }

	/// <summary>
	/// Items to display. 
	/// Base property for direct setup or to be re-published as <c>[Parameter] public</c>.
	/// </summary>
	protected IEnumerable<TItem> DataImpl { get; set; }

	/// <summary>
	/// Gets text to display from item. Used also for chip text.
	/// When not set ToString() is used.
	/// Base property for direct setup or to be re-published as <c>[Parameter] public</c>.
	/// </summary>
	protected Func<TItem, string> TextSelectorImpl { get; set; }

	/// <summary>
	/// Gets html to display from item.
	/// When not set <see cref="TextSelectorImpl"/> is used.
	/// </summary>
	protected RenderFragment<TItem> ItemTemplateImpl { get; set; }

	/// <summary>
	/// Selects value to sort items. Uses <see cref="TextSelectorImpl"/> property when not set.
	/// When complex sorting required, sort data manually and don't let sort them by this component. Alternatively create a custom comparable property.
	/// Base property for direct setup or to be re-published as <c>[Parameter] public</c>.
	/// </summary>
	protected Func<TItem, IComparable> SortKeySelectorImpl { get; set; }

	/// <summary>
	/// When <c>true</c>, items are sorted before displaying in select.
	/// Default value is <c>true</c>.
	/// Base property for direct setup or to be re-published as <c>[Parameter] public</c>.
	/// </summary>
	protected bool AutoSortImpl { get; set; } = true;

	/// <summary>
	/// Set of settings to be applied to the component instance (overrides <see cref="HxInputDate.Defaults"/>, overriden by individual parameters).
	/// </summary>
	[Parameter] public RadioButtonListSettings Settings { get; set; }

	/// <summary>
	/// Returns optional set of component settings.
	/// </summary>
	protected override RadioButtonListSettings GetSettings() => this.Settings;

	/// <inheritdoc cref="HxInputBase{TValue}.EnabledEffective" />
	protected override bool EnabledEffective => base.EnabledEffective && (itemsToRender != null);

	private protected override string CoreInputCssClass => throw new NotSupportedException();

	private IEqualityComparer<TValue> comparer = EqualityComparer<TValue>.Default;
	private List<TItem> itemsToRender;
	private int selectedItemIndex;
	private string chipValue;

	protected string GroupName { get; private set; }

	protected HxRadioButtonListBase()
	{
		GroupName = Guid.NewGuid().ToString("N");
	}

	/// <inheritdoc/>
	protected override void BuildRenderInput(RenderTreeBuilder builder)
	{
		chipValue = null;

		RefreshState();

		if (itemsToRender != null)
		{
			for (int i = 0; i < itemsToRender.Count; i++)
			{
				builder.OpenRegion(0);
				BuildRenderInput_RenderRadioItem(builder, i);
				builder.CloseRegion();
			}
		}
	}

	protected void BuildRenderInput_RenderRadioItem(RenderTreeBuilder builder, int index)
	{
		var item = itemsToRender[index];
		if (item != null)
		{
			bool selected = (index == selectedItemIndex);
			if (selected)
			{
				chipValue = SelectorHelpers.GetText(TextSelectorImpl, item);
			}

			string inputId = GroupName + "_" + index.ToString();

			builder.OpenElement(100, "label");

			// TODO CoreCssClass
			builder.AddAttribute(101, "class", CssClassHelper.Combine("form-check", this.Inline ? "form-check-inline" : null));
			builder.AddAttribute(102, "for", inputId);

			builder.OpenElement(200, "input");
			builder.AddAttribute(201, "class", "form-check-input");
			builder.AddAttribute(202, "type", "radio");
			builder.AddAttribute(203, "name", GroupName);
			builder.AddAttribute(204, "id", inputId);
			builder.AddAttribute(205, "value", index.ToString());
			builder.AddAttribute(206, "checked", selected);
			builder.AddAttribute(207, "disabled", !CascadeEnabledComponent.EnabledEffective(this));
			int j = index;
			builder.AddAttribute(208, "onclick", EventCallback.Factory.Create(this, () => HandleInputClick(j)));
			builder.AddEventStopPropagationAttribute(209, "onclick", true);
			builder.AddMultipleAttributes(250, this.AdditionalAttributes);
			builder.CloseElement(); // input

			builder.OpenElement(300, "label");
			builder.AddAttribute(301, "class", "form-check-label");
			builder.AddAttribute(302, "for", inputId);
			if (ItemTemplateImpl != null)
			{
				builder.AddContent(303, ItemTemplateImpl(item));
			}
			else
			{
				builder.AddContent(304, SelectorHelpers.GetText(TextSelectorImpl, item));
			}
			builder.CloseElement(); // label

			builder.CloseElement(); // div
		}
	}

	private void HandleInputClick(int index)
	{
		CurrentValue = SelectorHelpers.GetValue<TItem, TValue>(ValueSelectorImpl, itemsToRender[index]);
	}

	private void RefreshState()
	{
		if (DataImpl != null)
		{
			itemsToRender = DataImpl.ToList();

			// AutoSort
			if (AutoSortImpl && (itemsToRender.Count > 1))
			{
				if (SortKeySelectorImpl != null)
				{
					itemsToRender = itemsToRender.OrderBy(this.SortKeySelectorImpl).ToList();
				}
				else if (TextSelectorImpl != null)
				{
					itemsToRender = itemsToRender.OrderBy(this.TextSelectorImpl).ToList();
				}
				else
				{
					itemsToRender = itemsToRender.OrderBy(i => i.ToString()).ToList();
				}
			}

			// set next properties for rendering
			selectedItemIndex = itemsToRender.FindIndex(item => comparer.Equals(Value, SelectorHelpers.GetValue<TItem, TValue>(ValueSelectorImpl, item)));

			if ((Value != null) && (selectedItemIndex == -1))
			{
				throw new InvalidOperationException($"Data does not contain item for current value '{Value}'.");
			}
		}
		else
		{
			itemsToRender = null;
			selectedItemIndex = -1;
		}
	}

	/// <inheritdoc/>
	protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
	{
		throw new NotSupportedException();
	}

	protected override void RenderChipGenerator(RenderTreeBuilder builder)
	{
		if (!String.IsNullOrEmpty(chipValue))
		{
			base.RenderChipGenerator(builder);
		}
	}

	protected override void RenderChipValue(RenderTreeBuilder builder)
	{
		builder.AddContent(0, chipValue);
	}

}
