namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Customization request for specific date in calendar (<see cref="EcCalendar"/>, <see cref="EcInputDate{TValue}"/>, <see cref="EcInputDateRange"/>).
/// </summary>
public record CalendarDateCustomizationRequest
{
	/// <summary>
	/// Who is asking for a customization, where the customization will be applied.
	/// Allows distinguishing From and To inputs in <see cref="EcInputDateRange"/>.
	/// </summary>
	public CalendarDateCustomizationTarget Target { get; init; }

	/// <summary>
	/// Date to be customized.
	/// </summary>
	public DateTime Date { get; init; }
}