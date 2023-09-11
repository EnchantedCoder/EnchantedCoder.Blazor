namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcInputDate{TValue}"/>.
/// Marker for resources for <see cref="EcInputDate{TValue}"/>.
/// </summary>
public class EcInputDate
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcInputDate{TValue}"/>.
	/// </summary>
	public static InputDateSettings Defaults { get; set; }

	static EcInputDate()
	{
		Defaults = new InputDateSettings()
		{
			InputSize = InputSize.Regular,
			MinDate = EcCalendar.DefaultMinDate,
			MaxDate = EcCalendar.DefaultMaxDate,
			ShowClearButton = true,
			ShowPredefinedDates = true,
			PredefinedDates = new List<InputDatePredefinedDatesItem>() { new InputDatePredefinedDatesItem() { Label = "Today", ResourceType = typeof(EcInputDate), Date = DateTime.Today } }
		};
	}
}
