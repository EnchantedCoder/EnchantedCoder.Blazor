using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;
using Microsoft.Extensions.Localization;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Date picker. Form input component for entering a date.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcInputDate">https://EnchantedCoder.blazor.eu/components/EcInputDate</see>
/// </summary>
/// <remarks>
/// Defaults located in separate non-generic type <see cref="EcInputDate"/>.
/// </remarks>
public class EcInputDate<TValue> : EcInputBase<TValue>, IInputWithPlaceholder, IInputWithSize, IInputWithLabelType
{
	// DO NOT FORGET TO MAINTAIN DOCUMENTATION!
	private static HashSet<Type> supportedTypes = new HashSet<Type> { typeof(DateTime), typeof(DateTimeOffset) };

	/// <summary>
	/// Returns application-wide defaults for the component.
	/// Enables overriding defaults in descendants (use separate set of defaults).
	/// </summary>
	protected override InputDateSettings GetDefaults() => EcInputDate.Defaults;

	/// <summary>
	/// Set of settings to be applied to the component instance (overrides <see cref="EcInputDate.Defaults"/>, overridden by individual parameters).
	/// </summary>
	[Parameter] public InputDateSettings Settings { get; set; }

	/// <summary>
	/// Returns optional set of component settings.
	/// </summary>
	/// <remarks>
	/// Similar to <see cref="GetDefaults"/>, enables defining wider <see cref="Settings"/> in components descendants (by returning a derived settings class).
	/// </remarks>
	protected override InputDateSettings GetSettings() => this.Settings;

	/// <summary>
	/// When enabled (default is <c>true</c>), shows predefined days (from <see cref="PredefinedDates"/>, e.g. Today).
	/// </summary>
	[Parameter] public bool? ShowPredefinedDates { get; set; }
	protected bool ShowPredefinedDatesEffective => this.ShowPredefinedDates ?? this.Settings?.ShowPredefinedDates ?? GetDefaults().ShowPredefinedDates ?? throw new InvalidOperationException(nameof(ShowPredefinedDates) + " default for " + nameof(EcInputDate) + " has to be set.");

	/// <summary>
	/// Predefined dates to be displayed.
	/// </summary>
	[Parameter] public IEnumerable<InputDatePredefinedDatesItem> PredefinedDates { get; set; }
	private IEnumerable<InputDatePredefinedDatesItem> PredefinedDatesEffective => this.PredefinedDates ?? this.GetSettings()?.PredefinedDates ?? GetDefaults().PredefinedDates;

	/// <summary>
	/// Gets or sets the error message used when displaying a parsing error.
	/// Used with <c>String.Format(...)</c>, <c>{0}</c> is replaced by <c>Label</c> property, <c>{1}</c> name of bounded property.
	/// </summary>
	[Parameter] public string ParsingErrorMessage { get; set; }

	/// <inheritdoc cref="IInputWithPlaceholder.Placeholder" />
	[Parameter] public string Placeholder { get; set; }

	/// <summary>
	/// Size of the input.
	/// </summary>
	[Parameter] public InputSize? InputSize { get; set; }
	protected InputSize InputSizeEffective => this.InputSize ?? GetSettings()?.InputSize ?? GetDefaults()?.InputSize ?? throw new InvalidOperationException(nameof(InputSize) + " default for " + nameof(EcInputDate) + " has to be set.");
	InputSize IInputWithSize.InputSizeEffective => this.InputSizeEffective;

	/// <summary>
	/// Optional icon to display within the input. Use <see cref="EcInputDate.Defaults"/> to set the icon for the whole project.
	/// </summary>
	[Parameter] public IconBase CalendarIcon { get; set; }
	protected IconBase CalendarIconEffective => this.CalendarIcon ?? this.GetSettings()?.CalendarIcon ?? this.GetDefaults().CalendarIcon;

	/// <summary>
	/// Indicates whether the <i>Clear</i> button in dropdown calendar should be visible.<br/>
	/// Default is <c>true</c> (configurable in <see cref="EcInputDate.Defaults"/>).
	/// </summary>
	[Parameter] public bool? ShowClearButton { get; set; }
	protected bool ShowClearButtonEffective => this.ShowClearButton ?? this.GetSettings()?.ShowClearButton ?? this.GetDefaults().ShowClearButton ?? throw new InvalidOperationException(nameof(ShowClearButton) + " default for " + nameof(EcInputDate) + " has to be set.");

	/// <summary>
	/// First date selectable from the dropdown calendar.<br />
	/// Default is <c>1.1.1900</c> (configurable from <see cref="EcInputDate.Defaults"/>).
	/// </summary>
	[Parameter] public DateTime? MinDate { get; set; }
	protected DateTime MinDateEffective => this.MinDate ?? this.GetSettings()?.MinDate ?? GetDefaults().MinDate ?? throw new InvalidOperationException(nameof(MinDate) + " default for " + nameof(EcInputDate) + " has to be set.");

	/// <summary>
	/// Last date selectable from the dropdown calendar.<br />
	/// Default is <c>31.12.2099</c> (configurable from <see cref="EcInputDate.Defaults"/>).
	/// </summary>
	[Parameter] public DateTime? MaxDate { get; set; }
	protected DateTime MaxDateEffective => this.MaxDate ?? this.GetSettings()?.MaxDate ?? this.GetDefaults().MaxDate ?? throw new InvalidOperationException(nameof(MaxDate) + " default for " + nameof(EcInputDate) + " has to be set.");

	/// <summary>
	/// Allows customization of the dates in dropdown calendar.<br />
	/// Default customization is configurable with <see cref="EcInputDate.Defaults"/>.
	/// </summary>
	[Parameter] public CalendarDateCustomizationProviderDelegate CalendarDateCustomizationProvider { get; set; }
	protected CalendarDateCustomizationProviderDelegate CalendarDateCustomizationProviderEffective => this.CalendarDateCustomizationProvider ?? this.GetSettings()?.CalendarDateCustomizationProvider ?? GetDefaults().CalendarDateCustomizationProvider;

	/// <inheritdoc cref="Bootstrap.LabelType" />
	[Parameter] public LabelType? LabelType { get; set; }
	protected override LabelValueRenderOrder RenderOrder => (LabelType == Bootstrap.LabelType.Floating) ? LabelValueRenderOrder.ValueOnly /* label rendered by EcInputDateInternal */ : LabelValueRenderOrder.LabelValue;

	/// <summary>
	/// Custom CSS class to render with input-group span.
	/// </summary>
	[Parameter] public string InputGroupCssClass { get; set; }

	/// <summary>
	/// Input-group at the beginning of the input.
	/// </summary>
	[Parameter] public string InputGroupStartText { get; set; }
	/// <summary>
	/// Input-group at the beginning of the input.
	/// </summary>
	[Parameter] public RenderFragment InputGroupStartTemplate { get; set; }
	/// <summary>
	/// Input-group at the end of the input.
	/// </summary>
	[Parameter] public string InputGroupEndText { get; set; }
	/// <summary>
	/// Input-group at the end of the input.
	/// </summary>
	[Parameter] public RenderFragment InputGroupEndTemplate { get; set; }


	[Inject] private IStringLocalizer<EcInputDate> StringLocalizer { get; set; }


	public EcInputDate()
	{
		Type underlyingType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
		if (!supportedTypes.Contains(underlyingType))
		{
			throw new InvalidOperationException($"Unsupported type {typeof(TValue)}.");
		}
	}

	protected override void BuildRenderInput(RenderTreeBuilder builder)
	{
		RenderWithAutoCreatedEditContextAsCascadingValue(builder, 0, BuildRenderInputCore);
	}

	protected virtual void BuildRenderInputCore(RenderTreeBuilder builder)
	{
		LabelType labelTypeEffective = (this as IInputWithLabelType).LabelTypeEffective;

		builder.OpenComponent(1, typeof(EcInputDateInternal<TValue>));

		builder.AddAttribute(100, nameof(EcInputDateInternal<TValue>.Value), Value);
		builder.AddAttribute(101, nameof(EcInputDateInternal<TValue>.ValueChanged), EventCallback.Factory.Create<TValue>(this, value => CurrentValue = value));
		builder.AddAttribute(102, nameof(EcInputDateInternal<TValue>.ValueExpression), ValueExpression);

		builder.AddAttribute(200, nameof(EcInputDateInternal<TValue>.InputId), InputId);
		builder.AddAttribute(201, nameof(EcInputDateInternal<TValue>.InputCssClass), GetInputCssClassToRender());
		builder.AddAttribute(202, nameof(EcInputDateInternal<TValue>.EnabledEffective), EnabledEffective);
		builder.AddAttribute(203, nameof(EcInputDateInternal<TValue>.ParsingErrorMessageEffective), GetParsingErrorMessage());
		builder.AddAttribute(204, nameof(EcInputDateInternal<TValue>.Placeholder), (labelTypeEffective == EnchantedCoder.Blazor.Components.Web.Bootstrap.LabelType.Floating) ? "placeholder" : Placeholder);

		builder.AddAttribute(205, nameof(EcInputDateInternal<TValue>.InputSizeEffective), this.InputSizeEffective);
		builder.AddAttribute(206, nameof(EcInputDateInternal<TValue>.CalendarIconEffective), this.CalendarIconEffective);
		builder.AddAttribute(207, nameof(EcInputDateInternal<TValue>.PredefinedDatesEffective), this.PredefinedDatesEffective);
		builder.AddAttribute(207, nameof(EcInputDateInternal<TValue>.ShowPredefinedDatesEffective), this.ShowPredefinedDatesEffective);
		builder.AddAttribute(208, nameof(EcInputDateInternal<TValue>.ShowClearButtonEffective), ShowClearButtonEffective);
		builder.AddAttribute(209, nameof(EcInputDateInternal<TValue>.MinDateEffective), MinDateEffective);
		builder.AddAttribute(210, nameof(EcInputDateInternal<TValue>.MaxDateEffective), MaxDateEffective);
		builder.AddAttribute(211, nameof(EcInputDateInternal<TValue>.CalendarDateCustomizationProviderEffective), CalendarDateCustomizationProviderEffective);
		builder.AddAttribute(212, nameof(EcInputDateInternal<TValue>.LabelTypeEffective), labelTypeEffective);
		builder.AddAttribute(213, nameof(EcInputDateInternal<TValue>.FormValueComponent), this);

		builder.AddAttribute(214, nameof(EcInputDateInternal<TValue>.InputGroupStartText), this.InputGroupStartText);
		builder.AddAttribute(215, nameof(EcInputDateInternal<TValue>.InputGroupEndText), this.InputGroupEndText);
		builder.AddAttribute(216, nameof(EcInputDateInternal<TValue>.InputGroupStartTemplate), this.InputGroupStartTemplate);
		builder.AddAttribute(217, nameof(EcInputDateInternal<TValue>.InputGroupEndTemplate), this.InputGroupEndTemplate);
		builder.AddAttribute(218, nameof(EcInputDateInternal<TValue>.InputGroupCssClass), this.InputGroupCssClass);

		builder.AddMultipleAttributes(300, this.AdditionalAttributes);

		builder.CloseComponent();
	}

	// For generating chips
	/// <inheritdocs />
	protected override string FormatValueAsString(TValue value) => FormatValue(value);

	private protected override void BuildRenderInput_AddCommonAttributes(RenderTreeBuilder builder, string typeValue)
	{
		throw new NotSupportedException();
	}

	protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string validationErrorMessage)
	{
		throw new NotSupportedException();
	}

	/// <summary>
	/// Returns message for a parsing error.
	/// </summary>
	protected virtual string GetParsingErrorMessage()
	{
		var message = !String.IsNullOrEmpty(ParsingErrorMessage)
			? ParsingErrorMessage
			: StringLocalizer["ParsingErrorMessage"];
		return String.Format(message, Label, FieldIdentifier.FieldName);
	}

	internal static string FormatValue(TValue value)
	{
		// no 1.1.0001, etc.
		if (EqualityComparer<TValue>.Default.Equals(value, default))
		{
			return null;
		}

		switch (value)
		{
			case DateTime dateTimeValue:
				return dateTimeValue.ToShortDateString();
			case DateTimeOffset dateTimeOffsetValue:
				return dateTimeOffsetValue.DateTime.ToShortDateString();
			default:
				throw new InvalidOperationException("Unsupported type.");
		}
	}

	// for easy testability
	internal static bool TryParseDateTimeOffsetFromString(string value, CultureInfo culture, out DateTimeOffset? result)
	{
		if (String.IsNullOrWhiteSpace(value))
		{
			result = null;
			return true;
		}

		// it also works for "invalid dates" (with dots, commas, spaces...)
		// ie. 09,09,2020 --> 9.9.2020
		// ie. 09 09 2020 --> 9.9.2020
		// ie. 06,05, --> 6.5.ThisYear
		// ie. 06 05 --> 6.5.ThisYear
		bool success = DateTimeOffset.TryParse(value, culture, DateTimeStyles.AllowWhiteSpaces, out DateTimeOffset parsedValue) && (parsedValue.TimeOfDay == TimeSpan.Zero);
		if (success)
		{
			result = parsedValue;
			return true;
		}

		Match match;

		// 0105 --> 01.05.ThisYear
		match = Regex.Match(value, "^(\\d{2})(\\d{2})$");
		if (match.Success)
		{
			if (int.TryParse(match.Groups[1].Value, out int day)
				&& int.TryParse(match.Groups[2].Value, out int month))
			{
				try
				{
					result = new DateTimeOffset(new DateTime(DateTime.Now.Year, month, day));
					return true;
				}
				catch (ArgumentOutOfRangeException)
				{
					// NOOP
				}
			}
			result = null;
			return false;
		}

		// 01 --> 01.ThisMonth.ThisYear
		match = Regex.Match(value, "^(\\d{2})$");
		if (match.Success)
		{
			if (int.TryParse(match.Groups[1].Value, out int day))
			{
				try
				{
					result = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, day));
					return true;
				}
				catch (ArgumentOutOfRangeException)
				{
					// NOOP
				}
			}
			result = null;
			return false;
		}

		result = null;
		return false;
	}
}