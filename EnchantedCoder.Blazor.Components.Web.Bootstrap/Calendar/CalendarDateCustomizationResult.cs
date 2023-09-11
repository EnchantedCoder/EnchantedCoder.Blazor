namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Customization result for specific date in calendar (<see cref="EcCalendar"/>, <see cref="EcInputDate{TValue}"/>, <see cref="EcInputDateRange"/>).
/// </summary>
public class CalendarDateCustomizationResult
{
	/// <summary>
	/// Indicates whether the date is enabled.<br />
	/// Default value is <c>true</c>.
	/// </summary>
	public bool Enabled { get; init; } = true;

	/// <summary>
	/// Specifies additional CSS class for the date.
	/// </summary>
	public string CssClass { get; init; }
}