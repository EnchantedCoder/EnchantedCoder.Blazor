using System.Diagnostics.CodeAnalysis;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Component for single item selection with dynamic suggestions (based on typed characters).<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcAutosuggest">https://EnchantedCoder.blazor.eu/components/EcAutosuggest</see>
/// </summary>
/// <remarks>
/// Defaults located in separate non-generic type <see cref="EcAutosuggest"/>.
/// </remarks>
public class EcAutosuggest<TItem, TValue> : EcInputBase<TValue>, IInputWithSize, IInputWithPlaceholder, IInputWithLabelType
{
	/// <summary>
	/// Returns application-wide defaults for the component.
	/// Enables overriding defaults in descendants (use separate set of defaults).
	/// </summary>
	protected override AutosuggestSettings GetDefaults() => EcAutosuggest.Defaults;

	/// <summary>
	/// Set of settings to be applied to the component instance (overrides <see cref="EcAutosuggest.Defaults"/>, overridden by individual parameters).
	/// </summary>
	[Parameter] public AutosuggestSettings Settings { get; set; }

	/// <summary>
	/// Returns optional set of component settings.
	/// </summary>
	/// <remarks>
	/// Similar to <see cref="GetDefaults"/>, enables defining wider <see cref="Settings"/> in components descendants (by returning a derived settings class).
	/// </remarks>
	protected override AutosuggestSettings GetSettings() => this.Settings;


	/// <summary>
	/// Method (delegate) which provides data of the suggestions.
	/// </summary>
	[Parameter] public AutosuggestDataProviderDelegate<TItem> DataProvider { get; set; }

	/// <summary>
	/// Selects value from item.
	/// Not required when <c>TValue</c> is same as  <c>TItem</c>.
	/// </summary>
	[Parameter] public Func<TItem, TValue> ValueSelector { get; set; }

	/// <summary>
	/// Selects text to display from item.
	/// When not set <c>ToString()</c> is used.
	/// </summary>
	[Parameter] public Func<TItem, string> TextSelector { get; set; }

	/// <summary>
	/// Template to display item.
	/// When not set, <see cref="TextSelector"/> is used.
	/// </summary>
	[Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }

	/// <summary>
	/// Template to display when items are empty.
	/// </summary>
	[Parameter] public RenderFragment EmptyTemplate { get; set; }

	/// <summary>
	/// Icon displayed in input when no item is selected.
	/// </summary>
	[Parameter] public IconBase SearchIcon { get; set; }
	protected IconBase SearchIconEffective => this.SearchIcon ?? this.GetSettings()?.SearchIcon ?? GetDefaults().SearchIcon;

	/// <summary>
	/// Icon displayed in input on selection clear button when item is selected.
	/// </summary>
	[Parameter] public IconBase ClearIcon { get; set; }
	protected IconBase ClearIconEffective => this.ClearIcon ?? this.GetSettings()?.ClearIcon ?? GetDefaults().ClearIcon;

	/// <summary>
	/// Minimal number of characters to start suggesting.
	/// </summary>
	[Parameter] public int? MinimumLength { get; set; }
	protected int MinimumLengthEffective => this.MinimumLength ?? this.GetSettings()?.MinimumLength ?? GetDefaults().MinimumLength ?? throw new InvalidOperationException(nameof(MinimumLength) + " default for " + nameof(EcAutosuggest) + " has to be set.");

	/// <summary>
	/// Debounce delay in milliseconds.
	/// </summary>
	[Parameter] public int? Delay { get; set; }
	protected int DelayEffective => this.Delay ?? this.GetSettings()?.Delay ?? GetDefaults().Delay ?? throw new InvalidOperationException(nameof(Delay) + " default for " + nameof(EcAutosuggest) + " has to be set.");

	/// <summary>
	/// Short hint displayed in the input field before the user enters a value.
	/// </summary>
	[Parameter] public string Placeholder { get; set; }

	/// <summary>
	/// Size of the input.
	/// </summary>
	[Parameter] public InputSize? InputSize { get; set; }
	protected InputSize InputSizeEffective => this.InputSize ?? GetSettings()?.InputSize ?? GetDefaults()?.InputSize ?? throw new InvalidOperationException(nameof(InputSize) + " default for " + nameof(EcAutosuggest) + " has to be set.");
	InputSize IInputWithSize.InputSizeEffective => this.InputSizeEffective;

	/// <inheritdoc cref="Bootstrap.LabelType" />
	[Parameter] public LabelType? LabelType { get; set; }

	/// <summary>
	/// Offset between the dropdown and the input.
	/// <see href="https://popper.js.org/docs/v2/modifiers/offset/#options"/>
	/// </summary>
	protected virtual (int Skidding, int Distance) DropdownOffset { get; set; } = (0, 4);

	/// <summary>
	/// Returns corresponding item for (selected) Value.
	/// </summary>
	/// <remarks>
	/// We do not have full list of possible items to be able to select one by value.
	/// </remarks>
	[Parameter] public Func<TValue, Task<TItem>> ItemFromValueResolver { get; set; }

	protected override LabelValueRenderOrder RenderOrder => (LabelType == Bootstrap.LabelType.Floating) ? LabelValueRenderOrder.ValueOnly /* Label rendered by EcAutosuggestInternal */ : LabelValueRenderOrder.LabelValue;

	/// <summary>
	/// Input-group at the beginning of the input.
	/// </summary>
	[Parameter] public string InputGroupStartText { get; set; }

	/// <summary>
	/// Input-group at the beginning of the input.
	/// </summary>
	[Parameter] public RenderFragment InputGroupStartTemplate { get; set; }

	/// <summary>
	/// Input-group at the end of the input.<br/>
	/// Hides the search icon when used!
	/// </summary>
	[Parameter] public string InputGroupEndText { get; set; }

	/// <summary>
	/// Input-group at the end of the input.<br/>
	/// Hides the search icon when used!
	/// </summary>
	[Parameter] public RenderFragment InputGroupEndTemplate { get; set; }

	private protected override string CoreInputCssClass => "form-control";
	private protected override string CoreCssClass => "ec-autosuggest position-relative";

	private EcAutosuggestInternal<TItem, TValue> ecAutosuggestInternalComponent;

	/// <inheritdoc cref="ComponentBase.BuildRenderTree(RenderTreeBuilder)" />
	protected override void BuildRenderInput(RenderTreeBuilder builder)
	{
		LabelType labelTypeEffective = (this as IInputWithLabelType).LabelTypeEffective;

		builder.OpenComponent<EcAutosuggestInternal<TItem, TValue>>(1);

		builder.AddAttribute(1000, nameof(EcAutosuggestInternal<TItem, TValue>.Value), Value);
		builder.AddAttribute(1001, nameof(EcAutosuggestInternal<TItem, TValue>.ValueChanged), EventCallback.Factory.Create<TValue>(this, HandleValueChanged));
		builder.AddAttribute(1002, nameof(EcAutosuggestInternal<TItem, TValue>.DataProvider), DataProvider);
		builder.AddAttribute(1003, nameof(EcAutosuggestInternal<TItem, TValue>.ValueSelector), ValueSelector);
		builder.AddAttribute(1004, nameof(EcAutosuggestInternal<TItem, TValue>.TextSelector), TextSelector);
		builder.AddAttribute(1005, nameof(EcAutosuggestInternal<TItem, TValue>.ItemTemplate), ItemTemplate);
		builder.AddAttribute(1006, nameof(EcAutosuggestInternal<TItem, TValue>.MinimumLengthEffective), MinimumLengthEffective);
		builder.AddAttribute(1007, nameof(EcAutosuggestInternal<TItem, TValue>.DelayEffective), DelayEffective);
		builder.AddAttribute(1008, nameof(EcAutosuggestInternal<TItem, TValue>.InputId), InputId);
		builder.AddAttribute(1009, nameof(EcAutosuggestInternal<TItem, TValue>.InputCssClass), GetInputCssClassToRender()); // we may render "is-invalid" which has no sense here (there is no invalid-feedback following the element).
		builder.AddAttribute(1010, nameof(EcAutosuggestInternal<TItem, TValue>.EnabledEffective), EnabledEffective);
		builder.AddAttribute(1011, nameof(EcAutosuggestInternal<TItem, TValue>.ItemFromValueResolver), ItemFromValueResolver);
		builder.AddAttribute(1012, nameof(EcAutosuggestInternal<TItem, TValue>.Placeholder), (labelTypeEffective == EnchantedCoder.Blazor.Components.Web.Bootstrap.LabelType.Floating) ? "placeholder" : Placeholder);
		builder.AddAttribute(1013, nameof(EcAutosuggestInternal<TItem, TValue>.LabelTypeEffective), labelTypeEffective);
		builder.AddAttribute(1014, nameof(EcAutosuggestInternal<TItem, TValue>.FormValueComponent), this);
		builder.AddAttribute(1015, nameof(EcAutosuggestInternal<TItem, TValue>.EmptyTemplate), EmptyTemplate);
		builder.AddAttribute(1016, nameof(EcAutosuggestInternal<TItem, TValue>.SearchIconEffective), SearchIconEffective);
		builder.AddAttribute(1017, nameof(EcAutosuggestInternal<TItem, TValue>.ClearIconEffective), ClearIconEffective);
		builder.AddAttribute(1018, nameof(EcAutosuggestInternal<TItem, TValue>.DropdownOffset), DropdownOffset);
		builder.AddAttribute(1021, nameof(EcAutosuggestInternal<TItem, TValue>.InputGroupStartText), this.InputGroupStartText);
		builder.AddAttribute(1023, nameof(EcAutosuggestInternal<TItem, TValue>.InputGroupStartTemplate), this.InputGroupStartTemplate);
		builder.AddAttribute(1024, nameof(EcAutosuggestInternal<TItem, TValue>.InputGroupEndText), this.InputGroupEndText);
		builder.AddAttribute(1025, nameof(EcAutosuggestInternal<TItem, TValue>.InputGroupEndTemplate), this.InputGroupEndTemplate);

		builder.AddMultipleAttributes(2000, this.AdditionalAttributes);

		builder.AddComponentReferenceCapture(3000, component => ecAutosuggestInternalComponent = (EcAutosuggestInternal<TItem, TValue>)component);

		builder.CloseComponent();
	}

	private void HandleValueChanged(TValue newValue)
	{
		CurrentValue = newValue; // setter includes ValueChanged + NotifyFieldChanged
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string validationErrorMessage)
	{
		throw new NotSupportedException();
	}

	/// <inheritdoc />
	public override async ValueTask FocusAsync()
	{
		if (ecAutosuggestInternalComponent == null)
		{
			throw new InvalidOperationException($"Cannot focus {this.GetType()}. The method must be called after first render.");
		}

		await ecAutosuggestInternalComponent.FocusAsync();
	}

	/// <inheritdoc />
	protected override void RenderChipGenerator(RenderTreeBuilder builder)
	{
		if (!String.IsNullOrEmpty(ecAutosuggestInternalComponent?.ChipValue))
		{
			base.RenderChipGenerator(builder);
		}
	}

	/// <inheritdoc />
	protected override void RenderChipValue(RenderTreeBuilder builder)
	{
		builder.AddContent(0, ecAutosuggestInternalComponent.ChipValue);
	}
}
